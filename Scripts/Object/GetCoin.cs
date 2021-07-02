using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin: MonoBehaviour {

  private GameStats theGS;
  private SFXManager theSFXM;
  
  // Use this for initialization
  void Start() {
    theGS = FindObjectOfType < GameStats > ();
    theSFXM = FindObjectOfType < SFXManager > ();
  }

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.name == "FullBody") {
      theGS.addCoin();
      theSFXM.PlaySound("Coin");
      Destroy(gameObject);
    }

  }
}