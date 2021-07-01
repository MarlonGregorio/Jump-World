using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleManBigMovement: MonoBehaviour {

  private Rigidbody2D theRB;
  private Animator theAnimator;
  public BossHealthManager theBHM;

  public GameObject head;
  [Space]
  public GameObject spike;
  [Space]
  public GameObject headShield;
  [Space]
  public GameObject missle;

  private int simpleCount;
  private int waitCount;
  private GameObject thePlayer;
  private bool playerOnLeft = true;
  private bool fliped = true;
  private bool isSpike;

  private bool changingForm;
  public GameObject expolsion;
  public SpriteRenderer theSR;

  private int deathCount;
  public GameObject collisions;

  void Start() {
    theRB = GetComponent < Rigidbody2D > ();
    theAnimator = GetComponent < Animator > ();
    thePlayer = FindObjectOfType < Controller > ().gameObject;
  }

  void FixedUpdate() {
    if (theBHM.canMove && !theBHM.dead) {
      simpleCount++;

      facePlayer();

      if (!changingForm) {
        if (simpleCount < 90) {
          move();
        } else if (simpleCount < 120) {
          idle();
        } else if (simpleCount < 240) {
          attack();
        } else if (simpleCount < 270) {
          idle();
        } else if (simpleCount < 360) {
          move();
        } else if (simpleCount < 390) {
          idle();
        } else if (simpleCount < 510) {
          attack();
        } else if (simpleCount < 540) {
          idle();
        } else {
          simpleCount = 0;
          if (isSpike) {
            changingForm = true;
          }
        }
      } else if (changingForm && !isSpike) {
        if (simpleCount < 90) {
          theAnimator.Play("MissleManBigHide");

          if (simpleCount % 10 == 0) {
            head.transform.localPosition -= new Vector3(0, 1, 0);
            headShield.transform.localPosition -= new Vector3(0, 1, 0);
          }

          if (simpleCount == 89) {
            head.transform.localPosition = new Vector3(0, -12, 0);
            headShield.transform.localPosition = new Vector3(0, -12, 0);
          }

        } else if (simpleCount < 200) //was 240
        {
          theAnimator.Play("MissleManBigSpike");

          if (simpleCount % 10 == 0) {

            spike.transform.localPosition += new Vector3(0, 1, 0);
          }

          if (simpleCount == 199) {
            spike.transform.localPosition = new Vector3(0, 0, 0);

          }

        } else if (simpleCount >= 200) {
          isSpike = true;
          simpleCount = 0;
          changingForm = false;

        }
      } else if (changingForm && isSpike) {
        if (simpleCount < 60) {
          theAnimator.Play("MissleManBigSpikeHide");

          if (simpleCount % 10 == 0) {

            spike.transform.localPosition -= new Vector3(0, 1, 0);
          }

          if (simpleCount == 59) {
            spike.transform.localPosition = new Vector3(0, -12, 0);
          }

        } else if (simpleCount < 150) {
          theAnimator.Play("MissleManBigHeadShow");

          if (simpleCount % 10 == 0) {

            head.transform.localPosition += new Vector3(0, 1, 0);
            headShield.transform.localPosition += new Vector3(0, 1, 0);
          }

          if (simpleCount == 149) {
            head.transform.localPosition = new Vector3(0, 0, 0);
            headShield.transform.localPosition = new Vector3(0, 0, 0);

          }

        } else if (simpleCount >= 160) {
          isSpike = false;
          simpleCount = 0;
          changingForm = false;
        }
      }

      if (theBHM.hit && !changingForm)
      {
        if (theBHM.hitWithstands >= -1) {
          changingForm = true;
          simpleCount = 0;
        }

      }

    } else if (theBHM.dead) {
      deathCount++;
      if (deathCount == 1) {
        expolsion.SetActive(true);
        theRB.velocity = new Vector2(0, 0);
        theAnimator.Play("MissleManBigIdle");

        theRB.gravityScale = 0;
        GetComponent < Collider2D > ().isTrigger = true;
        spike.SetActive(false);
        head.GetComponent < Collider2D > ().isTrigger = true;
        collisions.SetActive(false);
        headShield.SetActive(false);

      }

      if (deathCount == 30) {
        Color color = theSR.color;
        color.a = 0;
        theSR.color = color;
      }
      if (deathCount == 60) {
        expolsion.SetActive(false);
      }
      if (deathCount == 200) {
        Destroy(gameObject);
      }

    }
  }

  private void facePlayer() {
    if (transform.position.x - thePlayer.transform.position.x > 0) {
      playerOnLeft = true;
    } else {
      playerOnLeft = false;
    }

    if (playerOnLeft && !fliped) {
      waitCount++;

      if (waitCount >= 200) {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        fliped = true;
        waitCount = 0;
      }
    } else if (!playerOnLeft && fliped) {
      waitCount++;

      if (waitCount >= 240) {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        fliped = false;
        waitCount = 0;
      }
    } else {
      waitCount = 0;
    }

  }

  private void move() {
    if (!isSpike) {
      theAnimator.Play("MissleManBigWalk");
    } else {
      theAnimator.Play("MissleManBigSpikeWalk");
    }

    if (fliped) {
      theRB.velocity = new Vector2(-40, 0);
    } else {
      theRB.velocity = new Vector2(40, 0);
    }
  }

  private void idle() {
    if (!isSpike) {
      theAnimator.Play("MissleManBigIdle");
    } else {
      theAnimator.Play("MissleManBigSpikeIdle");
    }

    theRB.velocity = new Vector2(0, 0);
  }

  private void attack() {
    if (!isSpike) {
      theAnimator.Play("MissleManBigFire");
    } else {
      theAnimator.Play("MissleManBigSpikeFire");
    }

    theRB.velocity = new Vector2(0, 0);

    if (simpleCount == 120 || simpleCount == 390) {
      if (transform.rotation.y == 0) {
        Instantiate(missle, transform.position - new Vector3(12, 5, 0), transform.rotation);
      } else {
        Instantiate(missle, transform.position - new Vector3(-12, 5, 0), transform.rotation);
      }
    }
  }
}