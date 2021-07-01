using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement: MonoBehaviour {

  private EnemyHealthManager theEHM;
  private Rigidbody2D theRB;
  public bool fliped;
  public hitWall theHitWall;

  void Start() {
    theEHM = GetComponent < EnemyHealthManager > ();
  }

  void Update() {
    if (theEHM.canMove) {
      theRB = GetComponent < Rigidbody2D > ();

      if (!theEHM.spear) {

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
      }
    }
  }
}