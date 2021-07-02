using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleMovement: MonoBehaviour {

  private Rigidbody2D theRB;
  private SFXManager theSFXM;
  private Controller theController;
  public bool step;
  private int counter;
  private int secondCounter;
  private bool toDestroy;
  private bool active;

  // Use this for initialization
  void Start() {
    theRB = GetComponent < Rigidbody2D > ();
    theSFXM = FindObjectOfType < SFXManager > ();
    theController = FindObjectOfType < Controller > ();
  }

  // Update is called once per frame
  void Update() {
    if (Mathf.Abs(transform.position.x - theController.gameObject.transform.position.x) < 150 || active) {
      active = true;

      if (!step) {
        if (transform.rotation.y == 0 && !toDestroy) {
          theRB.velocity = new Vector2(-50, 0);
        } else if (!toDestroy) {
          theRB.velocity = new Vector2(50, 0);
        }
      } else {
        counter++;

        if (counter == 1) {
          theSFXM.PlaySound("Stomp");
        }

        theRB.velocity = new Vector2(0, theRB.velocity.y);
        theRB.gravityScale = 5;
      }

      if (toDestroy) {
        secondCounter++;

        if (secondCounter == 30) {
          Destroy(gameObject);
        }
      }
    }
  }

  public void hit() {
    toDestroy = true; //make explode on player Too
    GetComponent < Collider2D > ().isTrigger = true;
    GetComponent < Animator > ().Play("missleExplode");
    theRB.velocity = new Vector2(0, 0);
  }

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name != "Feet" && collision.gameObject.name != "FullBody" && collision.gameObject.name != "JumpMan") {
      hit();
    }
  }
}