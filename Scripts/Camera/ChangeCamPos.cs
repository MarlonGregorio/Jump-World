using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamPos: MonoBehaviour {

  private CameraFollow theCam;
  private PlayerStartPoint thePS;
  public bool forceStopX;
  public bool forceStopY;
  public bool setNewLimitsX;
  public int theX;
  public int theY;

  void Start() {
    theCam = FindObjectOfType < CameraFollow > ();
    thePS = FindObjectOfType < PlayerStartPoint > ();
  }

  private void OnTriggerStay2D(Collider2D other) {
    if (other.gameObject.name == "FullBody") {
      if (forceStopY) {
        theCam.maxCameraPosition = new Vector3(theCam.maxCameraPosition.x, theCam.transform.position.y, -10);
      }

      if (forceStopX) {
        theCam.maxCameraPosition = new Vector3(theCam.transform.position.x, theCam.maxCameraPosition.y, -10);
      }

      if (setNewLimitsX) {
        theCam.maxCameraPosition = new Vector3(theX, theCam.maxCameraPosition.y, -10);
        theCam.minCameraPosition = new Vector3(theX, theCam.minCameraPosition.y, -10);

      }

      if (!forceStopX && !forceStopY && !setNewLimitsX) {
        theCam.maxCameraPosition = new Vector3(thePS.maxX, thePS.maxY, -10);
      }
    }
  }
}