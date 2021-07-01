using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleManSmallMovement: MonoBehaviour {

  private EnemyHealthManager theEHM;
  private Rigidbody2D theRB;
  public bool fliped;
  public GameObject Missle;
  private int counter = 100;
  public hitWall theHitWall;

  void Start() {
    theEHM = GetComponent < EnemyHealthManager > ();
  }

  void FixedUpdate() {
    if (theEHM.canMove) {
      theRB = GetComponent < Rigidbody2D > ();

      if (!theEHM.squish && !theEHM.spear) {

        if (theHitWall.hasHitWall && theRB.velocity.y == 0) {

          if (fliped) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            fliped = false;
            transform.position += new Vector3(3, 0, 0);
          } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            fliped = true;
            transform.position -= new Vector3(3, 0, 0);
          }

          theHitWall.hasHitWall = false;

        }

        if (fliped) {
          theRB.velocity = new Vector2(-30, theRB.velocity.y);
        } else {
          theRB.velocity = new Vector2(30, theRB.velocity.y);

        }

        counter++;

        if (counter >= 120) {

          if (counter == 120) {
            GetComponent < Animator > ().Play("missleManSmallFire");

            if (transform.rotation.y == 0) {
              Instantiate(Missle, transform.position - new Vector3(3.5 f, -3, 0), transform.rotation); //x 3.5 y  
            } else {
              Instantiate(Missle, transform.position - new Vector3(-7.5 f, -3, 0), transform.rotation);
            }

          }
          theRB.velocity = new Vector2(0, 0);

          if (counter >= 200) {
            counter = 0;
          }
        } else {
          GetComponent < Animator > ().Play("missleManSmallWalk");
        }

      } else if (!theEHM.spear) {
        GetComponent < Animator > ().Play("missleManSmallSquish");
      }
    }
  }
}