using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScore: MonoBehaviour {

  public GameObject star1;
  public GameObject star2;
  public GameObject star3;
  public Text score;

  public GameStats theGS;
  public SFXManager theSFXM;
  public MusicManager theMM;
  public PauseMenu thePM;

  public bool active;
  public int counter;
  private int secondCounter;
  private int starCount;
  private bool end;
  [Space]
  public int star3Score;

  void Start() {

  }

  void Update() {
    if (active) {

      secondCounter++;

      if (theGS.score <= 10) {
        active = false;
        counter = 0;
      }

      if (!end) {
        if (theGS.score < 2000) {
          counter += 10;
        } else if (theGS.score < 4000) {
          counter += 20;
        } else if (theGS.score < 6000) {
          counter += 30;
        } else {
          counter += 40;
        }
      }

      if (counter < 10) {
        score.text = "Score:     " + counter;
      } else if (counter < 100) {
        score.text = "Score:    " + counter;
      } else if (counter < 1000) {
        score.text = "Score:   " + counter;
      } else if (counter < 10000) {
        score.text = "Score:  " + counter;
      } else if (counter < 100000) {
        score.text = "Score: " + counter;
      }

      if (theGS.score > star3Score / 3 && !star1.activeSelf && secondCounter > 45) {
        star1.SetActive(true);
        theSFXM.PlaySound("Ding1");
        secondCounter = 0;
      }
      if (theGS.score > star3Score / 2 && !star2.activeSelf && secondCounter > 45) {
        star2.SetActive(true);
        theSFXM.PlaySound("Ding2");
        secondCounter = 0;
      }

      if (theGS.score > star3Score && !star3.activeSelf && secondCounter > 45) {
        star3.SetActive(true);
        theSFXM.PlaySound("Ding3");
        secondCounter = 0;
      }

      if (counter >= theGS.score) {
        if (!end) {
          end = true;
          counter = theGS.score;
        } else {
          active = false;
          end = false;
          counter = 0;
          secondCounter = 0;
          theSFXM.PlaySound("StopScore");
        }
      }
    }
  }

  public void endGame() {
    active = true;
    theSFXM.PlaySound("ScoreCount");

    theMM.musicCanPlay = false;

    if (theGS.score < star3Score / 3) {
      starCount = -1;
    }
    if (theGS.score > star3Score / 3) {
      starCount = 1;
    }
    if (theGS.score > star3Score / 2) {
      starCount = 2;
    }
    if (theGS.score > star3Score) {
      starCount = 3;
    }

    if (SceneManager.GetActiveScene().buildIndex <= 15) {
      if (starCount > theGS.mountainStars[SceneManager.GetActiveScene().buildIndex] || starCount == 0) {
        theGS.mountainStars[SceneManager.GetActiveScene().buildIndex] = starCount;
      }

    }
  }

  public void hideStats() {

    counter = 0;
    star3Score = 0;
    starCount = 0;
    active = false;
    star1.SetActive(false);
    star2.SetActive(false);
    star3.SetActive(false);
    score.text = "Score: ";
    theGS.score = 0;
    theGS.coins = 0;
    theSFXM.PlaySound("StopScore");
    thePM.toCloseEndGame = true;
  }
}