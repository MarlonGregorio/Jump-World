using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint: MonoBehaviour {

  private Controller thePlayer;
  private CameraFollow theCamera;

  public int minX;
  public int maxX;
  [Space]
  public int minY;
  public int maxY;

  // Use this for initialization
  void Start() {
    thePlayer = FindObjectOfType < Controller > ();

    if (thePlayer.spawnPoint == "Spawn") {
      thePlayer.transform.position = transform.position;
      thePlayer.transform.rotation = transform.rotation;
    }

    theCamera = FindObjectOfType < CameraFollow > ();
    theCamera.minCameraPosition = new Vector3(minX, minY, -10);
    theCamera.maxCameraPosition = new Vector3(maxX, maxY, -10);
  }
}