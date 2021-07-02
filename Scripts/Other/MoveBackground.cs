using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveBackground: MonoBehaviour {

  public GameObject background;
  public bool sure;
  private CameraFollow theCam;
  public Image theImage;
  private float initX;
  private float initY;

  void Start() {
    theCam = FindObjectOfType < CameraFollow > ();
    initX = theCam.transform.position.x;
    initY = theCam.transform.position.y;
  }

  void Update() {
    if (SceneManager.GetActiveScene().buildIndex <= 15) {
      //set wallpaper to mountains
    } else if (SceneManager.GetActiveScene().buildIndex <= 30) {
      //desert
    } else if (SceneManager.GetActiveScene().buildIndex <= 45) {
      //snow
    } else {
      //forest
    }

    theImage.enabled = true;
    if (sure) {
      transform.position += new Vector3((initX - theCam.transform.position.x) / 30.0 f, 0, 0);
    } else {
      transform.position += new Vector3((initX - theCam.transform.position.x) / 30.0 f, initY - theCam.transform.position.y, 0);
    }

    initX = theCam.transform.position.x;
    initY = theCam.transform.position.y;
  }
}