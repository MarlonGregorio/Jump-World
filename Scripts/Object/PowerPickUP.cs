using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickUP: MonoBehaviour {

  private SkillManager theSM;
  public string PowerUP;
  private int counter;

  void Start() {
    theSM = FindObjectOfType < SkillManager > ();
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (PowerUP == "Sheild" && collision.name == "FullBody") {
      theSM.activateShield(gameObject);
    }
    if (PowerUP == "Super" && collision.name == "FullBody") {
      theSM.turnSuper(gameObject);
    }
    if (PowerUP == "Meat" && collision.name == "FullBody") {
      theSM.turnStretchy(gameObject);
    }
  }

  void Update() {
    if (counter < 3) {
      counter++;
      transform.position += new Vector3(0, 2.2 f, 0);
    }
  }
}