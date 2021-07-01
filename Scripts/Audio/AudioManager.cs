using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour {

  private static bool managerExists;

  void Start() {
    if (!managerExists) {
      managerExists = true;
      DontDestroyOnLoad(transform.gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  // Update is called once per frame
  void Update() {

  }
}