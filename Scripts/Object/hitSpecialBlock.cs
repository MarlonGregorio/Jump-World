using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSpecialBlock: MonoBehaviour {

  private Animator theAnimator;
  private GameStats theGS;
  private bool ignite;
  private int counter;
  private SFXManager theSFXM;

  public string item;
  public Transform PowerUpPos;
  public GameObject sheild;
  public GameObject superBall;
  public GameObject meat;

  void Update() {
    if (ignite) {
      counter++;

      if (counter == 30) {
        ignite = false;
        counter = 1;
      }
    }
  }

  void Start() {
    theAnimator = GetComponent < Animator > ();
    theGS = FindObjectOfType < GameStats > ();
    theSFXM = FindObjectOfType < SFXManager > ();
  }

  public void active() {
    if (counter == 0) {
      ignite = true;

      if (item == "Coin") {
        theAnimator.Play("SBCoin");
        theGS.addCoin();
        theSFXM.PlaySound("Coin");
      } else if (item == "Shield") {
        theAnimator.Play("SBShield");
        Instantiate(sheild, PowerUpPos.position, Quaternion.identity);

      } else if (item == "Super") {
        theAnimator.Play("SBShield");
        Instantiate(superBall, PowerUpPos.position, Quaternion.identity);

      } else if (item == "Meat") {
        theAnimator.Play("SBShield");
        Instantiate(meat, PowerUpPos.position, Quaternion.identity);

      }
    }
  }
}