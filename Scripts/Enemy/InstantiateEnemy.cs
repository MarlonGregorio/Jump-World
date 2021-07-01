using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy: MonoBehaviour {

  private bool hasSpawned;
  public int zone;
  private CameraFollow theCam;

  public GameObject enemy;
  void Start() {
    theCam = FindObjectOfType < CameraFollow > ();
  }

  void Update() {
    if (theCam.currentZone == zone && !hasSpawned) {

      Instantiate(enemy, transform.position, Quaternion.identity);

      hasSpawned = true;

    } else if (theCam.currentZone != zone) {
      hasSpawned = false;
    }
  }
}