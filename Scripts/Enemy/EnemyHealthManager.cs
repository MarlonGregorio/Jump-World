using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager: MonoBehaviour {

  public bool squish;
  public bool spear;
  private int counter;
  private SFXManager theSFXM;
  private GameStats theGS;
  private Controller theController;
  public bool twoLives;
  public bool canMove;
  public EnemySpawnPipe theESP;
  private int check = 0;

  void Start() {
    theSFXM = FindObjectOfType < SFXManager > ();
    theGS = FindObjectOfType < GameStats > ();
    theController = FindObjectOfType < Controller > ();
  }

  void Update() {

    if (Mathf.Abs(transform.position.x - theController.gameObject.transform.position.x) < 150) {

      if (canMove == false && GetComponent < Rigidbody2D > () == null) {
        gameObject.AddComponent < Rigidbody2D > ();
        GetComponent < Rigidbody2D > ().gravityScale = theGS.dud.gravityScale;
        GetComponent < Rigidbody2D > ().freezeRotation = true;
      }

      if (theESP == null || check == 1) {
        canMove = true;
      }

    } else {
      canMove = false;
    }

    if (squish) {
      if (counter == 0) {
        theSFXM.PlaySound("Stomp");
        theGS.addScore(200);
      }

      counter++;

      if (counter == 10 && twoLives) {
        twoLives = false;
        counter = 0;
        squish = false;
      }

      if (counter == 20) {
        if (theESP != null) {
          theESP.currentSpawnCount -= 1;
        }

        Destroy(gameObject);
      }
    }

    if (spear) {
      if (counter == 0) {
        theSFXM.PlaySound("Stomp");
        theGS.addScore(200);
      }

      counter++;

      if (counter == 120) {
        if (theESP != null) {
          theESP.currentSpawnCount -= 1;
        }

        Destroy(gameObject);
      }
    }
  }

  public void speared() {
    spear = true;
    GetComponent < Collider2D > ().enabled = false;
    GetComponent < Rigidbody2D > ().velocity = new Vector2(0, 80);
    transform.rotation = Quaternion.Euler(0, 0, 180);
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.tag == "SpikeGround") {
      if (theESP != null) {
        theESP.currentSpawnCount -= 1;
      }
      Destroy(gameObject);
    }

    if (theESP != null && check == 0) {
      canMove = true;
      check = 1;
      if (GetComponent < CycloMovement > () != null) {
        GetComponent < CycloMovement > ().fliped = !GetComponent < CycloMovement > ().fliped;
      }
    }
  }
}