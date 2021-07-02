using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove: MonoBehaviour {

  public bool goesRight;
  [Space]
  public bool goesLeft;
  [Space]
  public bool goesDown;
  [Space]
  public bool goesUp;
  [Space]

  private int counter;
  private bool canMove;
  private Rigidbody2D theRB;
  public platformHolder theHolder;

  void Start() {
    theRB = GetComponent < Rigidbody2D > ();

    if (goesRight) {
      theRB.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
    if (goesLeft) {
      theRB.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
    if (goesDown) {
      theRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    if (goesUp) {
      theRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
  }

  void Update() {
    if (theHolder.inZone) {
      canMove = true;
    }

    if (canMove) {
      if (goesRight) {
        theRB.velocity = new Vector2(40, 0);
      }
      if (goesLeft) {
        theRB.velocity = new Vector2(-40, 0);
      }
      if (goesDown) {
        theRB.velocity = new Vector2(0, -40);
      }
      if (goesUp) {
        theRB.velocity = new Vector2(0, 40);
      }
    } else {
      theRB.velocity = new Vector2(0, 0);
    }
  }
}