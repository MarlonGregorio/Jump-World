using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class starCount: MonoBehaviour {

  private GameStats theGS;
  public string world;
  private Text uiText;
  private int mountainStars;
  private bool updated;

  void Start() {

    theGS = FindObjectOfType < GameStats > ();
    uiText = GetComponent < Text > ();

    if (world == "The Mountains") {
      for (int i = 0; i < theGS.mountainStars.Length; i++) {
        mountainStars += theGS.mountainStars[i];
      }

      uiText.text = "World Stars : " + mountainStars;
    }
  }
}