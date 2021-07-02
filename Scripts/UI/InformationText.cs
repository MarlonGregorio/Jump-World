using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationText: MonoBehaviour {

  public Text theText;
  public bool show;
  public bool hide;
  private int counter;

  void Start() {}

  void Update() {
    if (show) {
      Color color = GetComponent < Image > ().color;
      Color colorT = theText.color;
      colorT.a += .05 f;
      color.a += .05 f;
      GetComponent < Image > ().color = color;
      theText.color = colorT;

      if (color.a >= 1) {
        show = false;
      }
    }

    if (hide) {
      Color color = GetComponent < Image > ().color;
      Color colorT = theText.color;
      colorT.a -= .05 f;
      color.a -= 0.05 f;
      GetComponent < Image > ().color = color;
      theText.color = colorT;

      if (color.a <= 0) {
        hide = false;
      }
    }
  }

  public void changeText(string text) {
    theText.text = text;
  }

  public void showInfo() {
    show = true;
    hide = false;
  }

  public void hideInfo() {
    show = false;
    hide = true;
  }
}