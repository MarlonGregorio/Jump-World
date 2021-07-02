using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkPoint: MonoBehaviour {

  private Controller theController;
  public SpriteRenderer redFlag;
  public GameObject checkEffect;
  private SFXManager theSFXM;
  private bool active;

  void Start() {
    theController = FindObjectOfType < Controller > ();
    theSFXM = FindObjectOfType < SFXManager > ();

    if (theController.spawnPoint == "CheckPoint") {
      theController.transform.position = transform.position;
      theController.transform.rotation = transform.rotation;

      Color flagColor = redFlag.color;
      flagColor.a = 1;
      redFlag.color = flagColor;
    }
  }

  void Update() {
    if (active) {
      Color flagColor = redFlag.color;

      if (flagColor.a < 1) {
        flagColor.a += .04 f;
        redFlag.color = flagColor;
      } else {
        active = false;
      }
    }
  }

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.name == "JumpMan" && collision.GetComponent < Controller > ().spawnPoint == "Spawn") {
      theController.spawnPoint = "CheckPoint";
      active = true;
      checkEffect.SetActive(true);
      theSFXM.PlaySound("CheckPoint");
    }
  }
}