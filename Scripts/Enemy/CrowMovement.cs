using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMovement: MonoBehaviour {

  private EnemyHealthManager theEHM;
  private Rigidbody2D theRB;
  public bool fliped;
  private bool hitWall;
  private bool temp;
  public int counter;
  private float originalPos;
  private bool simpleBool;

  void Start() {
    theEHM = GetComponent < EnemyHealthManager > ();
    originalPos = transform.position.y;
  }

  void Update() {

    if (theEHM.canMove) {
      theRB = GetComponent < Rigidbody2D > ();
      theRB.gravityScale = 0;

      if (theRB.velocity.y != 0) {
        temp = true;
      }

      if (!theEHM.squish && !theEHM.spear) {

        if (hitWall && theRB.velocity.y == 0) {
          if (!temp) {
            if (fliped) {
              transform.rotation = Quaternion.Euler(0, 180, 0);
              fliped = false;
            } else {
              transform.rotation = Quaternion.Euler(0, 0, 0);
              fliped = true;
            }
          } else {
            temp = false;
          }

          hitWall = false;

        }

        counter++;

        if (fliped) {
          if (counter < 120) {
            theRB.velocity = new Vector2(-30, 0);
          } else if (originalPos - transform.position.y <= 40 && !simpleBool) {
            theRB.velocity = new Vector2(-30, -50);
            GetComponent < Animator > ().Play("crowDive");
          } else if (originalPos - transform.position.y >= 0) {
            simpleBool = true;
            theRB.velocity = new Vector2(-30, 50);
            GetComponent < Animator > ().Play("crowFly");
          } else {
            simpleBool = false;
            counter = 0;
          }

        } else {
          if (counter < 120) {
            theRB.velocity = new Vector2(30, 0);
          } else if (originalPos - transform.position.y <= 40 && !simpleBool) {
            theRB.velocity = new Vector2(30, -50);
            GetComponent < Animator > ().Play("crowDive");
          } else if (originalPos - transform.position.y >= 0) {
            simpleBool = true;
            theRB.velocity = new Vector2(30, 50);
            GetComponent < Animator > ().Play("crowFly");
          } else {
            simpleBool = false;
            counter = 0;
          }
        }
      } else if (!theEHM.spear) {
        GetComponent < Animator > ().Play("crowSquished");
        theRB.velocity = new Vector2(0, 0);
      } else {
        theRB.gravityScale = 30;
      }
    }
  }
}