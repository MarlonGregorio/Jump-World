using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreventButtonPress: MonoBehaviour {

  public bool left;
  public VolumeManager theVM;
  public SFXManager theSFXM;
  private bool trigger;

  void Update() {
    if (left && theVM.currentVolumeLevel < 0.3) {
      GetComponent < Button > ().onClick.RemoveAllListeners();
      trigger = false;
    } else if (left && !trigger) {
      GetComponent < Button > ().onClick.AddListener(theVM.lowerVolume);
      GetComponent < Button > ().onClick.AddListener(playSound);
      trigger = true;
    }

    if (!left && theVM.currentVolumeLevel > .9) {
      GetComponent < Button > ().onClick.RemoveAllListeners();
      trigger = false;
    } else if (!left && !trigger) {
      GetComponent < Button > ().onClick.AddListener(theVM.upVolume);
      GetComponent < Button > ().onClick.AddListener(playSound);
      trigger = true;
    }

  }

  private void playSound() {
    theSFXM.PlaySound("MenuClick");
  }
}