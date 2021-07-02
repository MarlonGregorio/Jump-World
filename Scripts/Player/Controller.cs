using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Controller: MonoBehaviour {

  public bool allowedToMove;
  [Space]
  public bool flipX;
  [Space]
  public float moveSpeed;
  public float jumpHeight;
  public bool initLand;

  public Collider2D theCollider;
  public Rigidbody2D theRigidbody;
  public SpriteRenderer theRenderer;
  public Animator theAnimator;
  public SkillManager theSM;

  public bool grounded;
  private bool secondJump;
  [Space]
  public static bool playerExists;
  public int coinsCount;
  [Space]

  public Vector3 leftSide;
  public Vector3 rightSide;
  public int difficulty;
  private int runCounter;
  private int baseSpeed = 30;

  public BoxCollider2D head;
  public Collider2D feet;
  public GameStats theGS;

  private SFXManager theSFXM;
  private bool simpleBool;
  private int simpleCount;

  public int worldSpeedX;
  public int worldSpeedY;
  public bool invincible;
  public int invinCount;
  [Space]
  public string spawnPoint;

  void Start() {
    Time.timeScale = 0;
    theCollider = GetComponent < Collider2D > ();
    theRigidbody = GetComponent < Rigidbody2D > ();
    theRenderer = GetComponent < SpriteRenderer > ();
    theAnimator = GetComponent < Animator > ();
    theSM = GetComponent < SkillManager > ();
    theSFXM = FindObjectOfType < SFXManager > ();

    if (!playerExists) {
      playerExists = true;
      DontDestroyOnLoad(transform.gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  void FixedUpdate() {
    checkGround();
  }

  void Update() {
    if (Time.timeScale == 1 && theCollider.enabled) {

      manageSpeed();
      moveInput();

      if (grounded) {
        if (Mathf.Abs(CnInputManager.GetAxisRaw("Horizontal")) == 0) {
          if (!theSM.usingSkill) {
            theAnimator.SetInteger("AnimState", 0); //Idle Anim
          } else {
            theAnimator.SetInteger("AnimState", 4);
          }

        } else if (allowedToMove) {
          if (!theSM.usingSkill) {
            theAnimator.SetInteger("AnimState", 1); //Walking Anim
          } else {
            theAnimator.SetInteger("AnimState", 5);
          }
        } else {
          if (!theSM.usingSkill) {
            theAnimator.SetInteger("AnimState", 0); //Idle Anim
          } else {
            theAnimator.SetInteger("AnimState", 4);
          }
        }
      } else {
        if (!simpleBool) {
          if (!theSM.usingSkill) {
            theAnimator.SetInteger("AnimState", 2); //jump
          } else {
            theAnimator.SetInteger("AnimState", 6);
          }

        } else {
          simpleCount++;
          if (simpleCount == 2) {
            theAnimator.SetInteger("AnimState", 0);
            simpleBool = false;
            simpleCount = 0;
          }
        }
      }
    }

    if (invincible) {
      invinCount++;

      SpriteRenderer playerSprite = GetComponent < SpriteRenderer > ();

      if (invinCount % 2 == 0) {
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0 f);
      } else {
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1 f);
      }

      if (invinCount >= 60) {
        invinCount = 0;
        invincible = false;
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1 f);

      }
    }
  }

  public void jump() {
    theRigidbody.velocity = new Vector2(theRigidbody.velocity.x, jumpHeight + worldSpeedY);
    theSFXM.PlaySound("Jump");
  }

  public void moveInput() {

    if (allowedToMove) {
      if ((Input.GetKeyDown(KeyCode.J) || CnInputManager.GetButtonDown("JumpButton")) && (grounded || secondJump)) {
        jump();

        if (!grounded) {
          secondJump = false;
          simpleBool = true;
        }
      }

      if (CnInputManager.GetAxisRaw("Horizontal") > 0) {
        theRigidbody.velocity = new Vector2(moveSpeed + worldSpeedX, theRigidbody.velocity.y);

        if (flipX == true) {
          transform.position += new Vector3(2, 0, 0);

        }
        flipX = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
      }

      if (CnInputManager.GetAxisRaw("Horizontal") < 0) {

        theRigidbody.velocity = new Vector2(-moveSpeed + worldSpeedX, theRigidbody.velocity.y);

        if (flipX == false) {
          transform.position -= new Vector3(2, 0, 0);

        }
        flipX = true;

        transform.rotation = Quaternion.Euler(0, 180, 0);
      }

      if (CnInputManager.GetAxisRaw("Horizontal") == 0) {

        if (theRigidbody.velocity.x - worldSpeedX > 0) {
          theRigidbody.velocity -= new Vector2(5 f, 0);
        }
        if (theRigidbody.velocity.x - worldSpeedX < 0) {
          theRigidbody.velocity += new Vector2(5 f, 0);
        }

        if (theRigidbody.velocity.x - worldSpeedX <= 5 && theRigidbody.velocity.x - worldSpeedX >= -5) {
          theRigidbody.velocity = new Vector2(0 + worldSpeedX, theRigidbody.velocity.y);
        }
      }
    }
  }

  public void manageSpeed() {
    if (Mathf.Abs(theRigidbody.velocity.x) > 0) {
      runCounter++;
      if (runCounter > 40) {
        runCounter = 40;
      }
    } else {
      runCounter = 0;
    }

    moveSpeed = baseSpeed + runCounter;
  }

  public IEnumerator knockBack(float duration, float power, int red) {
    int blue;
    if (flipX) {
      blue = 1;
    } else {
      blue = -1;
    }

    float timer = 0;
    while (duration > timer) {
      timer += Time.deltaTime;

      theRigidbody.velocity = new Vector2(0, 0);

      theRigidbody.AddForce(new Vector3(1750 * red * blue, 30 * power, transform.position.z));
    }

    yield
    return 0;
  }

  public void invokeControl() {
    allowedToMove = true;
  }

  public void revokeControl() {
    allowedToMove = false;
  }

  public void checkGround() {
    float red = 1.7 f;
    if (!flipX) {
      red = 2.8 f;
    }

    leftSide = transform.position;
    leftSide -= new Vector3(2 f + red, 9, 0);

    rightSide = transform.position;
    rightSide += new Vector3(6.5 f - red, -9, 0);

    Debug.DrawRay(leftSide, Vector3.down, Color.cyan);
    Debug.DrawRay(rightSide, Vector3.down, Color.red);

    if ((Physics2D.Raycast(leftSide, Vector3.down, 2) || Physics2D.Raycast(rightSide, Vector3.down, 2))) {
      grounded = true;
      secondJump = true;
    } else {
      grounded = false;
    }
  }

  private void OnCollisionStay2D(Collision2D collision) //might have to change to ONStay
  {
    if (!invincible) {
      if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spike") && !collision.gameObject.GetComponent < EnemyHealthManager > ().squish) {
        if (!theSM.shield.activeSelf && !theSM.isSuper && !theSM.isStretchy) {
          death();
        } else if (theSM.shield.activeSelf) {
          collision.gameObject.GetComponent < EnemyHealthManager > ().speared();
          theSM.shield.SetActive(false);
          invincible = true;
        } else if (theSM.isSuper || theSM.isStretchy) {
          theSM.turnBack();
          invincible = true;
        }

      } else if (collision.gameObject.tag == "SpikeGround") {
        death();
      } else if (collision.gameObject.tag == "SpikeGround2") {
        if (!theSM.shield.activeSelf && !theSM.isSuper && !theSM.isStretchy) {
          death();
        } else if (theSM.shield.activeSelf) {
          theSM.shield.SetActive(false);
          invincible = true;

        } else if (theSM.isSuper || theSM.isStretchy) {
          theSM.turnBack();
          invincible = true;
        }
      } else if (collision.gameObject.tag == "Missle" && !collision.gameObject.GetComponent < MissleMovement > ().step) {
        if (!theSM.shield.activeSelf && !theSM.isSuper && !theSM.isStretchy) {
          death();
        } else if (theSM.shield.activeSelf) {
          collision.gameObject.GetComponent < MissleMovement > ().step = true;
          collision.gameObject.GetComponent < Collider2D > ().isTrigger = true;
          theSM.shield.SetActive(false);

          invincible = true;
        } else if (theSM.isSuper || theSM.isStretchy) {
          theSM.turnBack();
          invincible = true;
        }

      } else if (collision.gameObject.tag == "FallingSpike") {
        if (!theSM.shield.activeSelf && !theSM.isSuper && !theSM.isStretchy) {
          death();
        } else if (theSM.shield.activeSelf) {
          collision.gameObject.GetComponent < SpikeBallFall > ().spin();
          theSM.shield.SetActive(false);

          invincible = true;
        } else if (theSM.isSuper || theSM.isStretchy) {
          theSM.turnBack();
          invincible = true;
        }
      }
    }
  }

  public void death() {
    theAnimator.SetInteger("AnimState", 3); //death
    theRigidbody.velocity = new Vector2(0, 150);
    head.enabled = false;
    feet.enabled = false;
    theCollider.enabled = false;
    allowedToMove = false;
    theSFXM.PlaySound("Death");
    theGS.resetLevel(false);
    theSM.shield.SetActive(false);
  }
}