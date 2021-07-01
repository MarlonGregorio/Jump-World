using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager: MonoBehaviour {

  public VolumeController[] vcObjects;
  public float currentVolumeLevel;
  public float MaxVolumeLevel = 1.0 f;
  public Text volumeLevel;

  private float currentLevel = 5;
  private float setVolume;
  private bool toLower;
  private bool toHigher;
  private int counter;
  private static bool managerExists;

  void Start() {

    setVolume = currentVolumeLevel * 5;
    if (currentVolumeLevel == 0) {
      currentLevel = 0;
    }

    vcObjects = FindObjectsOfType < VolumeController > ();

    if (!managerExists) {
      managerExists = true;
      DontDestroyOnLoad(transform.gameObject);
    } else {
      Destroy(gameObject);
    }

    if (currentVolumeLevel > MaxVolumeLevel) {
      currentVolumeLevel = MaxVolumeLevel;

    }

    volumeLevel.text = "" + currentLevel;

    for (int i = 0; i < vcObjects.Length; i++) {
      vcObjects[i].SetAudioLevel(currentVolumeLevel);
    }
  }

  void Update() {

    if (toLower) {

      counter++;

      if (counter % 4 == 0 && currentLevel >= .5) {
        currentLevel -= .5 f;
        currentVolumeLevel -= .1 f;

        for (int i = 0; i < vcObjects.Length; i++) {
          vcObjects[i].SetAudioLevel(currentVolumeLevel);
        }
      }

      if (counter == 42) {
        counter = 0;
        currentVolumeLevel = 0;
        toLower = false;

      }
    }

    if (toHigher) {
      counter++;

      if (counter % 4 == 0 && currentLevel < setVolume) {
        currentLevel += .5 f;
        currentVolumeLevel += .1 f;

        for (int i = 0; i < vcObjects.Length; i++) {
          vcObjects[i].SetAudioLevel(currentVolumeLevel);
        }
      }

      if (counter == 42) {
        counter = 0;

        toHigher = false;

      }
    }

  }

  public void upVolume() {
    currentVolumeLevel += .2 f;
    currentLevel += 1;

    if (currentVolumeLevel > MaxVolumeLevel) {
      currentVolumeLevel = MaxVolumeLevel;
    }

    if (currentLevel > 5) {
      currentLevel = 5;
    }

    setVolume = currentLevel;

    volumeLevel.text = "" + currentLevel;

    for (int i = 0; i < vcObjects.Length; i++) {
      vcObjects[i].SetAudioLevel(currentVolumeLevel);
    }
  }

  public void lowerVolume() {
    currentVolumeLevel -= .2 f;
    currentLevel -= 1;

    if (currentLevel <= 0) {
      currentLevel = 0;
    }

    if (currentVolumeLevel <= 0) {
      currentVolumeLevel = 0;
    }

    setVolume = currentLevel;

    volumeLevel.text = "" + currentLevel;

    for (int i = 0; i < vcObjects.Length; i++) {
      vcObjects[i].SetAudioLevel(currentVolumeLevel);
    }
  }

  public void slowlyLower() {
    toLower = true;
  }

  public void slowlyHigher() {
    toHigher = true;
  }
}