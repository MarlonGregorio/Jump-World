﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpear: MonoBehaviour {

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.tag == "Enemy") {
      collision.GetComponent < EnemyHealthManager > ().speared();
    }
  }
}