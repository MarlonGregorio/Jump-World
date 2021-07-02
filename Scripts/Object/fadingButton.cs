using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadingButton: MonoBehaviour {

  public PrologueManager thePM;
  public bool canCount;
  private int counter;
  private Button thisButton;
  private Image thisImage;
  public Text thisText;

  // Use this for initialization
  void Start() {
    thisButton = GetComponent < Button > ();
    thisImage = GetComponent < Image > ();
  }

  // Update is called once per frame
  void Update() {

    if (canCount) {
      counter++;

      if (counter == 1) {
        thisButton.transform.position += new Vector3(0, 100, 0);
      }

      if (counter == 120) {
        thisButton.transform.position -= new Vector3(0, 100, 0);
      }

      if (counter > 120 && counter < 160) {
        Color temp = thisImage.color;
        Color temp2 = thisText.color;

        temp.a += .05 f;
        temp2.a += .05 f;
        thisButton.interactable = true;

        if (temp.a >= 1) {
          temp.a = 1;
          temp2.a = 1;

        }
        thisImage.color = temp;
        thisText.color = temp2;
      }

      if (counter > 320 && counter < 360) {
        Color temp = thisImage.color;
        Color temp2 = thisText.color;

        temp.a -= .05 f;
        temp2.a -= .05 f;

        if (temp.a <= 0) {
          temp.a = 0;
          temp2.a = 0;
          thisButton.interactable = false;
        }
        thisImage.color = temp;
        thisText.color = temp2;
      }

      if (counter == 360) {
        thisButton.transform.position += new Vector3(0, 100, 0);
      }
    }
  }

  public void showButton() {
    if (counter > 360) {
      counter = 115;
    }

  }
}