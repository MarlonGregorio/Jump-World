using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSign: MonoBehaviour {

  public string text;
  private InformationText theIT;

  void Start() {
    theIT = FindObjectOfType < InformationText > ();
  }

  void Update() {

  }

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.name == "JumpMan") {
      theIT.changeText(text);
      theIT.showInfo();
    }
  }

  void OnTriggerExit2D(Collider2D collision) {
    if (collision.gameObject.name == "JumpMan") {
      theIT.hideInfo();
    }
  }
}