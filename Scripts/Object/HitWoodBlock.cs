using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWoodBlock: MonoBehaviour {

  private Animator theAnimator;
  private int counter;

  void Start() {
    theAnimator = GetComponent < Animator > ();
  }

  public IEnumerator hitBlock() {
    theAnimator.Play("hitWB");
    yield
    return new WaitForSeconds(.5 f); //half a sec
    theAnimator.Play("New State");
  }
}