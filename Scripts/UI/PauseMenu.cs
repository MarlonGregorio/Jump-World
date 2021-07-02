using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu: MonoBehaviour {

  public EndScore theES;
  public bool paused;
  public Controller theController;
  public CameraFollow theCam;
  public WindowManager theWM;
  public MusicManager theMM;
  public ScreenFade theSF;

  private bool ignite;
  private bool toClose;
  private bool toLevel;
  private int levelCounter;
  private int toCounter;
  private int counter;
  private bool toSave;
  private int savCount;

  public Image arrow1;
  public Image arrow2;
  public Image arrow3;
  public Image pause;
  public GameStats theGS;
  public Image sign;
  public Text signText;
  public GameObject options;
  public SFXManager theSFXM;
  public Image DarkScreen;

  [Space]

  public GameObject PauseUI;
  public Image homeButton;
  public Image resetButton;
  public Image optionButton;
  public Image unPause;
  public Text pauseText;

  [Space]

  public GameObject EndGame;
  public Text endGameTitle;
  public Text endGameScore;
  public Image nextLevel;
  public Image homeEnd;
  public Image resetEnd;
  public bool endGameActive;
  private bool endGameActivated;
  public bool toCloseEndGame;
  public bool transitioning;

  void Update() {

    if (toClose) {
      toCounter++;

      if (toCounter == 45) {
        theES.hideStats();

        toCounter = 0;
        toClose = false;

        theController.spawnPoint = "Spawn";
        theCam.target = theController.gameObject;

        theCam.gameObject.transform.position = new Vector3(0, 12, -10);
        theController.gameObject.transform.position = new Vector3(-60, -6, -1);
      }
    }
    if (ignite) {
      counter++;

      if (counter == 45) {
        theCam.target = theController.gameObject;
        theController.worldSpeedX = 0;
        theController.worldSpeedY = 0;

        theController.spawnPoint = "Spawn";

        SceneManager.LoadScene(0);

        if (SceneManager.GetActiveScene().buildIndex <= 15) {
          theWM.openForestWorld();
        }

        counter = 0;
        theGS.coins = 0;
        theGS.score = 0;
        ignite = false;
        paused = false;

        Color orignal = sign.color;
        orignal.a = 0;
        sign.color = orignal;

        Color orignalText = signText.color;
        orignalText.a = 0;
        signText.color = orignalText;
      }
    }

    if (Input.GetButtonDown("Pause") && theController.allowedToMove && SceneManager.GetActiveScene().buildIndex > 0 && !options.activeSelf) {

      if (!transitioning) {
        paused = !paused;
        if (paused) {
          theSFXM.PlaySound("Pause");
        } else {
          theSFXM.PlaySound("UnPause");
        }
      }
    }

    if (paused) {
      showPauseUI();
      showBackground();
      Time.timeScale = 0;
      hideMobile();

    } else {
      if (!endGameActive)
      {
        Time.timeScale = 1;
        hideBackground();
        hidePauseUI();

        showMobile();
      } else {

        if (!toCloseEndGame) {
          showEndGame();
          showBackground();
          hideMobile();
          if (Time.timeScale != 0) {
            toSave = true;
            Time.timeScale = 0;
          }
        } else {
          hideEndGame();
          showMobile();
          hideBackground();
        }
      }
    }

    if (toSave)
    {
      savCount++;

      if (savCount == 30) {
        FindObjectOfType < GameStats > ().saveGame();
        savCount = 0;
        toSave = false;
      }
    }
  }

  public void resume() {
    paused = !paused;
  }

  public void mainMenu() {
    if (!transitioning) {
      theSF.beginFade();
      theMM.slowSwitch(0, 40);

      hidePauseUI();
      ignite = true;

      if (EndGame.activeSelf) {
        closeEndGame(true);
      }

      theSFXM.PlaySound("MenuClick");
    }
  }

  public void nextTem() {
    if (!transitioning) {
      theES.theGS.GetComponent < GameStats > ().loadScene(SceneManager.GetActiveScene().buildIndex + 1);
      theSF.beginFade();
      closeEndGame(true);
      theSFXM.PlaySound("MenuClick");
    }
  }

  public void closeEndGame(bool test) //set to true if delay 
  {

    if (test) {
      toClose = true;
      hideBackground();
      hideEndGame();
      showMobile();

    } else {
      theES.hideStats();

      hideBackground(); //these need to take place imediatley
      hideEndGame();
      showMobile();
    }
  }

  public void hideMobile() {
    Color color = arrow1.color;
    Color pauseColor = pause.color;

    if (color.a > 0) {
      color.a -= .04 f;
      pauseColor.a -= .04 f;

      arrow1.color = color;
      arrow2.color = color;
      arrow3.color = color;
      pause.color = pauseColor;
    }
  }

  public void showMobile() {
    Color color = arrow1.color;
    Color pauseColor = pause.color;

    if (color.a < 1) {
      pauseColor.a += .04 f;
      color.a += .04 f;
      arrow1.color = color;
      arrow2.color = color;
      arrow3.color = color;
      pause.color = pauseColor;
    }
  }

  public void showBackground() {
    Color original = DarkScreen.color;

    if (original.a < .5) {
      original.a += .02 f;
      DarkScreen.color = original;

    }
  }

  public void hideBackground() {
    Color original = DarkScreen.color;

    if (original.a > 0) {
      original.a -= .02 f;
      DarkScreen.color = original;

    }
  }

  public void showPauseUI() {
    PauseUI.SetActive(true);

    Color original = homeButton.color;

    if (original.a < 1) {
      original.a += .04 f;
      transitioning = true;

      homeButton.color = original;
      resetButton.color = original;
      optionButton.color = original;
      unPause.color = original;
      pauseText.color = original;

    }

    if (original.a >= 1) {
      transitioning = false;
    }
  }

  public void hidePauseUI() {

    Color original = homeButton.color;

    if (original.a > 0) {
      original.a -= .04 f;
      transitioning = true;

      homeButton.color = original;
      resetButton.color = original;
      optionButton.color = original;
      unPause.color = original;
      pauseText.color = original;

    } else {
      if (PauseUI.activeSelf) {
        transitioning = false;
      }
      PauseUI.SetActive(false);

    }
  }

  public void showEndGame() {
    Color original = homeEnd.color;
    EndGame.SetActive(true);

    if (original.a < 1) {
      original.a += .04 f;
      transitioning = true;

      homeEnd.color = original;
      resetEnd.color = original;
      nextLevel.color = original;
      endGameTitle.color = original;
      endGameScore.color = original;

    } //integrate hide end game into home and reset press if active

    if (original.a >= 1) {
      if (!endGameActivated) {

        endGameActivated = true;
        transitioning = false;
      }
    }
  }

  public void hideEndGame() {
    Color original = homeEnd.color;

    if (original.a > 0) {
      original.a -= .08 f;
      transitioning = true;
      homeEnd.color = original;
      resetEnd.color = original;
      nextLevel.color = original;
      endGameTitle.color = original;
      endGameScore.color = original;
    }

    if (original.a <= 0) {
      endGameActivated = false;
      endGameActive = false;
      EndGame.SetActive(false);
      transitioning = false;
      toCloseEndGame = false;
    }
  }

  public void buttonPause() {
    if (!transitioning) {
      if (EndGame.activeSelf) {
        closeEndGame(false);
        theMM.musicCanPlay = true;
        theController.allowedToMove = true;
      } else {
        paused = !paused;
      }
      if (paused) {
        theSFXM.PlaySound("Pause");
      } else {
        theSFXM.PlaySound("UnPause");
      }
    }
  }

  public void showOptions() {
    if (!transitioning) {
      options.SetActive(true);
      theSFXM.PlaySound("MenuClick");
    }
  }
}