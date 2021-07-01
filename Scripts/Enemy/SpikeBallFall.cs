using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallFall: MonoBehaviour {

  private Rigidbody2D theRB;
  private int counter;
  private SFXManager theSFXM;


  // Use this for initialization
  void Start() {
    theRB = GetComponent < Rigidbody2D > ();
    theSFXM = FindObjectOfType < SFXManager > ();
  }


  // Update is called once per frame
  void Update() {

    counter++;
    if (counter == 240) {
      Destroy(gameObject);
    }
    theRB.velocity = new Vector2(0, -50);
  }

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.tag == "SpikeGround") {
      GetComponent < BoxCollider2D > ().isTrigger = true;
    }
  }

  public void spin() {
    theSFXM.PlaySound("Stomp");
    GetComponent < Animator > ().Play("spikeSpin");
    GetComponent < Collider2D > ().isTrigger = true;
  }
}