using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class SkillManager: MonoBehaviour {

  private GameStats theGS;
  private SFXManager theSFXM;
  private Animator theAnimator;

  public Animator SuperJumpMan;
  public Animator StretchyJumpMan;
  public Animator jumpMan;

  public bool isSuper;
  public bool isStretchy;
  public GameObject shootButton;
  public GameObject punchButton;

  public GameObject blast;
  public GameObject fist;
  public GameObject shield;
  public Transform attackPoint;
  public bool usingSkill;
  public int counter;

  void Start() {

    theGS = FindObjectOfType < GameStats > ();
    theSFXM = FindObjectOfType < SFXManager > ();
    theAnimator = GetComponent < Animator > ();
  }

  void Update() {

    if (isSuper && (Input.GetKeyDown(KeyCode.K) || CnInputManager.GetButtonDown("Shoot"))) {
      if (counter > 100) {
        Instantiate(blast, new Vector3(attackPoint.position.x, attackPoint.position.y, attackPoint.position.z), transform.rotation);
        usingSkill = true;
        theSFXM.PlaySound("Blast");
        counter = 0;
      }
    }

    if (isStretchy && (Input.GetKeyDown(KeyCode.K) || CnInputManager.GetButtonDown("Punch"))) {
      if (counter > 100) {
        fist.SetActive(true);
        theSFXM.PlaySound("Punch");
        usingSkill = true;
        counter = 0;
      }
    }

    counter++;
    if (counter > 40) {
      usingSkill = false;
    }

    if (counter > 40) {
      fist.SetActive(false);
    }
  }

  public void activateShield(GameObject self) {
    Destroy(self);
    theGS.addScore(1000);
    theSFXM.PlaySound("PowerUp");
    shield.SetActive(true);
  }

  public void turnSuper(GameObject theG) {
    Destroy(theG);
    theAnimator.runtimeAnimatorController = SuperJumpMan.runtimeAnimatorController;
    isSuper = true;
    shootButton.SetActive(true);
    theSFXM.PlaySound("PowerUp");

    isStretchy = false;
    punchButton.SetActive(false);

  }

  public void turnStretchy(GameObject theG) {
    Destroy(theG);
    theAnimator.runtimeAnimatorController = StretchyJumpMan.runtimeAnimatorController;
    isStretchy = true;
    punchButton.SetActive(true);
    theSFXM.PlaySound("PowerUp");

    isSuper = false;
    shootButton.SetActive(false);
  }

  public void turnBack() {
    theAnimator.runtimeAnimatorController = jumpMan.runtimeAnimatorController;
    isSuper = false;
    isStretchy = false;
    shootButton.SetActive(false);
    punchButton.SetActive(false);
    counter = 100;
  }

  public void resetSkills() {
    turnBack();
    shield.SetActive(false);
  }
}