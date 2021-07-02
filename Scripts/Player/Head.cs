using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head: MonoBehaviour {

  private SFXManager theSFXM;

  void Start() {
    theSFXM = FindObjectOfType < SFXManager > ();
  }

  void Update() {

  }

  void OnCollisionEnter2D(Collision2D collision) {
    theSFXM.PlaySound("HitBlock");

    if (collision.gameObject.name == "WoodBlock" || collision.gameObject.name == "GroundBlock" || collision.gameObject.name == "BaseBlock") {
      collision.gameObject.GetComponent < HitWoodBlock > ().StartCoroutine("hitBlock");
    }

    if (collision.gameObject.name == "SpecialBlock") {
      collision.gameObject.GetComponent < hitSpecialBlock > ().active();
    }
  }
}