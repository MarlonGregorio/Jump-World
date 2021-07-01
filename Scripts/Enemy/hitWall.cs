using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitWall: MonoBehaviour {

  public bool hasHitWall;

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.name != "JumpMan" && collision.gameObject.name != "FullBody" && collision.gameObject.name != "Feet" && collision.gameObject.name != "ChangeCameraPos") {
      if (collision.gameObject.GetComponent < MissleMovement > () == null) //might have to add in for blast and punch
      {
        hasHitWall = true;
      }

    }

  }
  
  void OnTriggerExit2D(Collider2D collision) {
    if (collision.gameObject.name != "JumpMan" && collision.gameObject.name != "FullBody" && collision.gameObject.name != "Feet" && collision.gameObject.name != "ChangeCameraPos") {
      if (collision.gameObject.GetComponent < MissleMovement > () == null) //might have to add in for blast and punch
      {
        hasHitWall = false;
      }
    }
  }
}