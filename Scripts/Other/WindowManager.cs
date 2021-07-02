using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowManager: MonoBehaviour {

  public GameObject startMenu;
  public GameObject options;

  public GameObject selectWorld;
  public GameObject forestWorld;
  public GameObject desertWorld;
  public GameObject mobileControls;

  public GameStats theGS;
  public ScreenFade theSF;
  public PrologueManager thePM;
  public MusicManager theMM;
  public SFXManager theSFXM;

  void Update() {
    if (SceneManager.GetActiveScene().buildIndex == 0 && Input.GetKeyDown(KeyCode.Escape)) {
      if (!startMenu.activeSelf) {
        if (selectWorld.activeSelf) {
          openStartMenu();
          theSFXM.PlaySound("MenuClick");
        } else if (forestWorld.activeSelf || desertWorld.activeSelf) //and so on
        {
          openSelectWorld();
          theSFXM.PlaySound("MenuClick");
        }
      } else if (options.activeSelf) {
        openStartMenu();
        theSFXM.PlaySound("MenuClick");
      }
    } else if (SceneManager.GetActiveScene().buildIndex > 0 && Input.GetKeyDown(KeyCode.Escape)) {
      if (options.activeSelf) {
        options.SetActive(false);
        theSFXM.PlaySound("MenuClick");
      }
    }
  }

  public void openStartMenu() {
    startMenu.SetActive(true);
    options.SetActive(false);
    selectWorld.SetActive(false);
    forestWorld.SetActive(false);
    desertWorld.SetActive(false);
  }

  public void openOptions() {
    options.SetActive(true);
    selectWorld.SetActive(false);
    forestWorld.SetActive(false);
    desertWorld.SetActive(false);
  }

  public void openSelectWorld() {
    if (!theGS.prologueComplete) {
      options.SetActive(false);

      selectWorld.SetActive(false);
      forestWorld.SetActive(false);
      desertWorld.SetActive(false);
      theSF.beginFade();
      theMM.slowSwitch(1, 40);
      thePM.ignite = true;

    } else {
      startMenu.SetActive(false);
      options.SetActive(false);
      selectWorld.SetActive(true);
      forestWorld.SetActive(false);
      desertWorld.SetActive(false);
    }

  }

  public void openForestWorld() {
    startMenu.SetActive(false);
    options.SetActive(false);
    selectWorld.SetActive(false);
    forestWorld.SetActive(true);
    desertWorld.SetActive(false);
  }

  public void OpenDesertWorld() {
    startMenu.SetActive(false);
    options.SetActive(false);
    selectWorld.SetActive(false);
    forestWorld.SetActive(false);
    desertWorld.SetActive(true);
  }

  public void closeAll() {
    startMenu.SetActive(false);
    options.SetActive(false);
    selectWorld.SetActive(false);
    forestWorld.SetActive(false);
    desertWorld.SetActive(false);
  }

  public void quitGame() {
    Application.Quit();
  }
}