using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogMovement: MonoBehaviour {

  private EnemyHealthManager theEHM;
  private Rigidbody2D theRB;
  public bool fliped;
  public hitWall theHitWall;
  private int frogCount;

  void Start() {
    theEHM = GetComponent < EnemyHealthManager > ();
  }

  void Update() {

    if (theEHM.canMove) {
      theRB = GetComponent < Rigidbody2D > ();

      if (!theEHM.squish && !theEHM.spear) {

        if (theHitWall.hasHitWall) {

          if (fliped) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            fliped = false;
          } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            fliped = true;
          }

          theHitWall.hasHitWall = false;

        }

        frogCount++;

        if (frogCount < 60) {
          GetComponent < Animator > ().Play("frogIdle");
          theRB.velocity = new Vector2(0, theRB.velocity.y);
        } else if (frogCount == 60) {
          GetComponent < Animator > ().Play("frogJump");
        }

        if (fliped) {

          if (frogCount == 100) {
            theRB.velocity = new Vector2(-20, 150);
          }

        } else {

          if (frogCount == 100) {
            theRB.velocity = new Vector2(20, 150);
          }
        }

        if (frogCount < 180 && frogCount > 120) {
          if (theRB.velocity.y < 0) {
            GetComponent < Animator > ().Play("frogFall");
          } else if (theRB.velocity.y == 0) {
            GetComponent < Animator > ().Play("frogLand");
          }
        } else if (frogCount == 180) {
          frogCount = 0;
        }
      } else if (!theEHM.spear) {

        GetComponent < Animator > ().Play("frogSquished");
      }
    }
  }
}