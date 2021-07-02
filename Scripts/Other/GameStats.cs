using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameStats: MonoBehaviour {
  public bool prologueComplete;
  public Controller theController;
  public MusicManager theMM;
  public CameraFollow theCamera;

  public int score;
  public Text scoreText;
  public int coins;
  public Text coinsText;
  public int totalCoins;

  public Text time;
  private bool active;
  private int counter;
  private int frames;

  private bool dieing;
  private int delay;

  private bool toLoad;
  private int toScene;
  private int loadCount;

  public sceneFade theSF;
  public PauseMenu thePM;
  public ScreenFade theSCF;
  public WindowManager theWM;

  [Space]
  public bool[] mountainLevels;
  [Space]
  public int[] mountainStars;
  [Space]
  public bool[] desertLevels;
  [Space]
  public int[] desertStars;
  [Space]
  public bool[] snowLevels;
  [Space]
  public int[] snowStars;
  [Space]
  public bool[] forestLevels;
  [Space]
  public int[] forestStars;
  [Space]
  public bool[] specialLevels;
  [Space]
  public int[] specialStars;
  [Space]
  public Rigidbody2D dud;
  [Space]

  public Image sign;
  public Text signText;

  void Start() {
    loadGame();
  }

  void Update() {

    if (score < 100) {
      scoreText.text = "Score:  " + score;
    } else if (score < 1000) {
      scoreText.text = "Score:  " + score;
    } else {
      scoreText.text = "Score: " + score;
    }

    if (coins < 10) {
      coinsText.text = "Coins:  " + coins;
    } else {
      coinsText.text = "Coins: " + coins;
    }

    if (!thePM.paused) {
      if (active) {
        frames++;

        if (frames == 60) {
          frames = 0;
          counter--;
          if (counter < 0) {
            counter = 0;
          }

          if (counter < 10) {
            time.text = "Time:   " + counter;
          } else if (counter < 100) {
            time.text = "Time:  " + counter;
          } else {
            time.text = "Time: " + counter;
          }

          if (counter == 0) {
            theController.death();
          }
        }
      }
    }

    if (dieing) {
      delay++;

      if (delay == 120) {
        theCamera.target = theController.gameObject;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        theController.theSM.resetSkills();
        theController.theCollider.enabled = true;
        theController.feet.enabled = true;
        theController.head.enabled = true;
        theController.allowedToMove = true;
        delay = 0;
        coins = 0;
        score = 0;
        dieing = false;

      }
    }

    if (toLoad) {
      loadCount++;
      if (loadCount == 40) {

        SceneManager.LoadScene(toScene);
        theController.theSM.resetSkills();
        theCamera.gameObject.transform.position = new Vector3(0, 12, -10);
        Time.timeScale = 1;
        theWM.closeAll();
        loadCount = 0;
        toLoad = false;
      }
    }
  }

  public void addCoin() {
    coins += 1;
    addScore(50);
  }

  public void addCoinTotal() {
    totalCoins += coins;
  }

  public void resetLevel(bool instant) {
    if (!instant) {
      dieing = true;
    } else {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

      if (SceneManager.GetActiveScene().buildIndex <= 15) {
        if (theCamera.target.name != "JumpMan") {
          theMM.slowSwitch(1, 40);
        }
      }

      theCamera.target = theController.gameObject;

      theController.worldSpeedX = 0;
      theController.worldSpeedY = 0;

      theController.theSM.resetSkills();
      Time.timeScale = 1;
      coins = 0;
      score = 0;
      theWM.closeAll();
      loadCount = 0;
      toLoad = false;

      Color orignal = sign.color;
      orignal.a = 0;
      sign.color = orignal;

      Color orignalText = signText.color;
      orignalText.a = 0;
      signText.color = orignalText;
    }

    stopTimer();
  }

  public void addScore(int x) {
    score += x;
  }

  public void setTimer(int x) {
    active = true;
    counter = x;
    time.text = "Time: " + counter;
  }

  public void stopTimer() {
    active = false;
    frames = 0;
  }

  public void loadScene(int x) {
    if (toLoad == false) {
      theSCF.beginFade();
      toLoad = true;
      theController.allowedToMove = true;
      toScene = x;

      if (SceneManager.GetActiveScene().buildIndex <= 15) {
        theMM.slowSwitch(1, 40);

      } else if (SceneManager.GetActiveScene().buildIndex <= 30) {
        theMM.slowSwitch(2, 40);
      }

    }

  }

  public void saveGame() {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create(Application.persistentDataPath + "/" + 1 + " playerInfo.dat");

    PlayerData data = new PlayerData();

    data.mountainLevels = mountainLevels;
    data.mountainStars = mountainStars;

    data.desertLevels = desertLevels;
    data.desertStars = desertStars;

    data.snowLevels = snowLevels;
    data.snowStars = snowStars;

    data.forestLevels = forestLevels;
    data.forestStars = forestStars;

    data.specialLevels = specialLevels;
    data.specialStars = specialStars;

    data.totalCoins = totalCoins;

    data.prologueComplete = prologueComplete;

    bf.Serialize(file, data);
    file.Close();
  }

  public void loadGame() {
    if (File.Exists(Application.persistentDataPath + "/" + 1 + " playerInfo.dat")) {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + "/" + 1 + " playerInfo.dat", FileMode.Open);
      PlayerData data = (PlayerData) bf.Deserialize(file);
      file.Close();

      mountainLevels = data.mountainLevels;
      mountainStars = data.mountainStars;

      desertLevels = data.desertLevels;
      desertStars = data.desertStars;

      snowLevels = data.snowLevels;
      snowStars = data.snowStars;

      forestLevels = data.forestLevels;
      forestStars = data.forestStars;

      specialLevels = data.specialLevels;
      specialStars = data.specialStars;

      totalCoins = data.totalCoins;
      mountainLevels[0] = true;

      prologueComplete = data.prologueComplete;
      saveGame();
    }
  }

  public void deleteSave() {
    File.Delete(Application.persistentDataPath + "/" + 1 + " playerInfo.dat");
    //need to wipe all levels if button stays
  }

  public void quitGame() {
    Application.Quit();
  }

  public void unlockLevels() //also will save
  {
    for (int i = 0; i <= 10; i++) {
      mountainLevels[i] = true;
    }

    saveGame();
  }
}

[Serializable]
class PlayerData {

  public bool[] mountainLevels;
  public int[] mountainStars;

  public bool[] desertLevels;
  public int[] desertStars;

  public bool[] snowLevels;
  public int[] snowStars;

  public bool[] forestLevels;
  public int[] forestStars;

  public bool[] specialLevels;
  public int[] specialStars;

  public int totalCoins;
  public bool prologueComplete;

}