using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet: MonoBehaviour {

  public Controller theController;
  public SkillManager theSM;
  public bool impacting;

  void Start() {

  }

  void Update() {

  }

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.tag == "Enemy" && !collision.gameObject.GetComponent < EnemyHealthManager > ().squish) {
      collision.gameObject.GetComponent < EnemyHealthManager > ().squish = true;
      theController.theRigidbody.velocity = new Vector2(theController.theRigidbody.velocity.x, 140);
    } else if (collision.gameObject.tag == "Missle") {
      theController.theRigidbody.velocity = new Vector2(theController.theRigidbody.velocity.x, 140);
      collision.gameObject.GetComponent < MissleMovement > ().step = true;
      collision.gameObject.GetComponent < Collider2D > ().isTrigger = true;
    }

    impacting = true;
  }
}