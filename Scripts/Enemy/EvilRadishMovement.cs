using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRadishMovement: MonoBehaviour {

  private EnemyHealthManager theEHM;
  private Rigidbody2D theRB;
  private int counter;
  public int delay;
  private int delayCounter;
  public bool fliped;
  private bool small;
  private bool small2;
  private bool speared;
  private float originalPos;

  void Start() {
    theEHM = GetComponent < EnemyHealthManager > ();
    theRB = GetComponent < Rigidbody2D > ();
    originalPos = transform.position.y;
  }

  void Update() {

    delayCounter++;

    if (delay < delayCounter) {
      if (!theEHM.squish && !theEHM.spear) {

        if (small && !small2) {
          GetComponent < Animator > ().Play("EvilRadishFall");
          small2 = true;
        }

        if (fliped) {
          transform.rotation = Quaternion.Euler(0, 0, 0);
        } else {
          transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (!small) {
          if (counter == 0 && transform.position.y - originalPos < 40) {
            theRB.velocity = new Vector2(0, 50);
          } else {
            counter = 1;
          }

          if (counter == 1 && transform.position.y - originalPos >= 0) {
            theRB.velocity = new Vector2(0, -50);

          } else {
            counter = 0;
          }
        } else {
          if (theRB.velocity.y == 0) {
            GetComponent < Animator > ().Play("EvilRadishNormal");
          }
          theRB.velocity = new Vector2(0, -100);
        }

      } else if (!theEHM.spear) {
        if (small2) {
          GetComponent < Animator > ().Play("EvilRadishSquish");
        }
        small = true;
      } else {
        if (!speared) {
          theRB.velocity = new Vector2(0, 80);
          speared = true;
          theRB.gravityScale = 30;
        }
      }
    }
  }
}