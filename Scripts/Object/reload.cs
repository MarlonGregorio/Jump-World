using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnControls;

public class reload: MonoBehaviour {

  public GameObject mobileControls;
  [Space]
  public SkillManager theSM;
  public Image theImage;
  [Space]
  public GameObject arrow1;
  public GameObject arrow2;
  public GameObject jumpShade;
  private float reloadValue;

  void Update() {
    reloadValue = (100 f - theSM.counter) / 100 f;
    if (reloadValue <= 0) {
      reloadValue = 0;
    }

    if (mobileControls.activeSelf) {
      theImage.fillAmount = reloadValue;

      if (CnInputManager.GetAxisRaw("Horizontal") > 0) {
        arrow1.SetActive(true);
        arrow2.SetActive(false);
      } else if (CnInputManager.GetAxisRaw("Horizontal") < 0) {
        arrow1.SetActive(false);
        arrow2.SetActive(true);
      } else {
        arrow1.SetActive(false);
        arrow2.SetActive(false);
      }

      if (Input.GetKey(KeyCode.J) || CnInputManager.GetButton("JumpButton")) {
        jumpShade.SetActive(true);
      } else //if(Input.GetKeyUp(KeyCode.J) || CnInputManager.GetButtonUp("JumpButton")
      {
        jumpShade.SetActive(false);
      }
    }
  }
}