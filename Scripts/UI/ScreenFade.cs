using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade: MonoBehaviour {

  public Image screen;
  private bool fadingIn;
  private bool fadingOut;
  private bool delay;
  private int delayCounter;

  void Update() {

    if (fadingIn) {
      Color alpha = screen.color;
      alpha.a += .03 f;
      screen.color = alpha;

      if (alpha.a >= 1) {
        fadingIn = false;
        delay = true;
        alpha.a = 1;
        screen.color = alpha;
      }
    }

    if (delay) {
      delayCounter++; {
        if (delayCounter == 20) {
          delay = false;
          delayCounter = 0;
          fadingOut = true;
        }
      }
    }

    if (fadingOut) {
      Color alpha = screen.color;
      alpha.a -= .03 f;
      screen.color = alpha;

      if (alpha.a <= 0) {
        fadingOut = false;
        alpha.a = 0;
        screen.color = alpha;
      }
    }
  }

  public void beginFade() {
    fadingIn = true;
  }
}