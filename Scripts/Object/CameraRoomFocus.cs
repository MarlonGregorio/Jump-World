using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomFocus: MonoBehaviour {

  private CameraFollow theCam;
  public bool triggerBossFight;
  private bool set;
  private MusicManager theMM;
  public int musicSwitch;

  void Start() {
    theCam = FindObjectOfType < CameraFollow > ();
    theMM = FindObjectOfType < MusicManager > ();
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.name == "JumpMan" && !set) {
      theCam.target = transform.gameObject;
      if (triggerBossFight) {
        FindObjectOfType < BossHealthManager > ().canMove = true;
        theMM.slowSwitch(musicSwitch, 40);
        set = true;
      }
    }
  }
}