using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punch: MonoBehaviour {

  private Controller theController;

  void Start() {
    theController = FindObjectOfType < Controller > ();
    Physics2D.IgnoreCollision(GetComponent < BoxCollider2D > (), theController.theCollider);
  }

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spike") {
      collision.gameObject.GetComponent < EnemyHealthManager > ().speared();
    }
  }
}