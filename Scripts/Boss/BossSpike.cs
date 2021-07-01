using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpike: MonoBehaviour {

  private

  void Start() {

  }

  void Update() {

  }

  private void OnCollisionStay2D(Collision2D collision) {
    if (collision.gameObject.name == "JumpMan") {
      if (!collision.gameObject.GetComponent < Controller > ().invincible) {
        if (collision.gameObject.GetComponent < SkillManager > ().shield.activeSelf) {
          collision.gameObject.GetComponent < SkillManager > ().shield.SetActive(false);
          collision.gameObject.GetComponent < Controller > ().invincible = true;

        } else {
          collision.gameObject.GetComponent < Controller > ().death();
        }
      }
    }
  }
}