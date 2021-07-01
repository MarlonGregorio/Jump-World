using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager: MonoBehaviour {

  public int hitWithstands;
  [Space]
  public bool canMove;
  [Space]
  public bool hit;
  [Space]
  public bool dead;

  private int hitCount;
  private SFXManager theSFXM;
  private PauseMenu thePM;
  private Controller theController;
  private EndScore theES;
  private GameStats theGS;
  private bool levelComplete;
  private int levelCounter;

  [Space]
  public int star3Score;
  public int time;


  void Start() {
    theSFXM = FindObjectOfType < SFXManager > ();
    thePM = FindObjectOfType < PauseMenu > ();
    theController = FindObjectOfType < Controller > ();
    theES = FindObjectOfType < EndScore > ();
    theGS = FindObjectOfType < GameStats > ();

    theES.star3Score = star3Score;
    theGS.setTimer(time);
  }

  void Update() {
    if (hit) {
      hitCount++;

      if (hitCount == 120) {
        hitCount = 0;
        hit = false;
      }
    }

    if (levelComplete) {
      levelCounter++;

      if (levelCounter >= 120) {
        thePM.endGameActive = true;
        levelComplete = false;
        levelCounter = 0;
        theES.endGame();
      }
    }

  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "JumpMan") {
      if (!hit) {
        hitWithstands -= 1;
      }

      hit = true;

      if (hitWithstands == 0) {
        dead = true;
        thePM.transitioning = true;
        theSFXM.PlaySound("EndLevel");
        theController.allowedToMove = false;
        theController.theRigidbody.velocity = new Vector2(0, 140);
        levelComplete = true;
        theGS.addScore(1000);
      } else {
        theSFXM.PlaySound("Stomp");
        collision.gameObject.GetComponent < Rigidbody2D > ().velocity = new Vector2(collision.gameObject.GetComponent < Rigidbody2D > ().velocity.x, 140);
      }

    }
  }
}