using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepMovement: MonoBehaviour {

  private EnemyHealthManager theEHM;
  private Rigidbody2D theRB;
  public bool fliped;
  private bool small;
  private bool small2;
  private bool speared;
  public hitWall theHitWall;

  void Start() {
    theEHM = GetComponent < EnemyHealthManager > ();
  }

  void Update() {

    if (theEHM.canMove) {
      theRB = GetComponent < Rigidbody2D > ();

      if (!theEHM.squish && !theEHM.spear) {

        if (small) {
          GetComponent < Animator > ().Play("creepWalkSmall");
          GetComponent < BoxCollider2D > ().offset = new Vector2(0, 5);
          GetComponent < BoxCollider2D > ().size = new Vector3(12, 10, 0);
          small2 = true;
        }

        if (theHitWall.hasHitWall && theRB.velocity.y == 0) {
          if (fliped) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            fliped = false;
          } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            fliped = true;
          }

          theHitWall.hasHitWall = false;
        }

        if (fliped) {
          theRB.velocity = new Vector2(-30, theRB.velocity.y);
        } else {
          theRB.velocity = new Vector2(30, theRB.velocity.y);

        }
      } else if (!theEHM.spear) {
        if (small2) {
          GetComponent < Animator > ().Play("creepSquish");
        }
        small = true;
      } else {
        if (!speared) {
          speared = true;
          if (small) {
            transform.position += new Vector3(0, 10, 0);
          } else {
            transform.position += new Vector3(0, 20, 0);
          }

        }
      }
    }
  }
}