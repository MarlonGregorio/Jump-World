using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneFade: MonoBehaviour {

  public Texture2D fadeOutTexture;
  public float fadeSpeed = 1.0 f;
  private int drawDepth = -1000;
  private float alpha = 0.0 f;
  private int fadeDir = -1;
  public bool ignite;
  private int counter;

  void OnGUI()
  {
    alpha += fadeDir * fadeSpeed * Time.deltaTime;
    alpha = Mathf.Clamp01(alpha);
    GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
    GUI.depth = drawDepth;
    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
  }

  public float BeginFade(int direction) {
    fadeDir = direction;
    ignite = true;
    return (fadeSpeed);
  }

  void Update() {
    if (ignite) {
      counter++;
      if (counter == 55) {
        BeginFade(-1);
        ignite = false;
        counter = 0;
      }
    }
  }
}