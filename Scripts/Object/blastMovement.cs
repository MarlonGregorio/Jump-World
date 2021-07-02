using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastMovement: MonoBehaviour {

  private Rigidbody2D theRB;
  private int counter;

  // Use this for initialization
  void Start() {
    theRB = GetComponent < Rigidbody2D > ();
  }

  // Update is called once per frame
  void Update() {
    counter++;

    if (transform.rotation.y == 0) {
      theRB.velocity = new Vector2(150, 0);
    } else {
      theRB.velocity = new Vector2(-150, 0);
    }

    if (counter >= 90) {
      Destroy(gameObject);
    }
  }

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spike") {
      if (collision.gameObject.GetComponent < Rigidbody2D > () != null) {
        collision.gameObject.GetComponent < EnemyHealthManager > ().speared();
      }

    }

    if (collision.gameObject.tag == "Missle" && !collision.gameObject.GetComponent < MissleMovement > ().step) {
      collision.gameObject.GetComponent < MissleMovement > ().hit();

    }

    if (collision.GetComponent < Collider2D > () != null && collision.GetComponent < Collider2D > ().isTrigger == false) {
      Destroy(gameObject);
    }
  }
}