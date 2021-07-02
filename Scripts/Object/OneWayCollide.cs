using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollide: MonoBehaviour {

  private GameObject stand;

  // Use this for initialization
  void Start() {
    stand = transform.Find("Collider").gameObject;
  }

  void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.name == "FullBody") {
      stand.SetActive(false);
    }
  }

  void OnTriggerExit2D(Collider2D collision) {
    if (collision.gameObject.name == "FullBody") {
      stand.SetActive(true);
    }
  }
}