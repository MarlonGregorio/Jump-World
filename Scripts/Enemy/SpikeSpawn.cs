using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawn: MonoBehaviour {

  public GameObject spikeBall;
  private Animator theAnimator;
  private int counter;
  public int delay;
  private int delayCounter;

  // Use this for initialization
  void Start() {
    theAnimator = GetComponent < Animator > ();
  }

  // Update is called once per frame
  void Update() {

    delayCounter++;
    if (delay < delayCounter) {
      counter++;
      if (counter == 200) {
        theAnimator.Play("RoofTrapIdle");
      }

      if (counter == 240) {
        theAnimator.Play("RoofTrapShoot");
        Instantiate(spikeBall, transform.position - new Vector3(0, 3, 0), Quaternion.Euler(0, 0, 0));
        counter = 0;
      }
    }
  }
}