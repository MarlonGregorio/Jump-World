using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockInfo: MonoBehaviour {

  public string toName;
  private Text changeName;
  public int beatLevel;
  public string world;
  [Space]

  public Sprite regular;
  public Sprite noStar;
  public Sprite oneStar;
  public Sprite twoStar;
  public Sprite threeStar;

  private Image toChange;
  private GameStats theGS;
  private WindowManager theWM;
  public int numStar;


  void Start() {
    theGS = FindObjectOfType < GameStats > ();
    toChange = GetComponent < Image > ();
    theWM = FindObjectOfType < WindowManager > ();
    changeName = transform.GetChild(0).gameObject.GetComponent < Text > ();
  }

  void Update() {

    if (world == "Mountain") {
      if (theGS.mountainLevels[beatLevel]) {
        numStar = theGS.mountainStars[beatLevel + 1];

        if (numStar == 0) {
          toChange.sprite = regular;
        } else if (numStar == -1) {
          toChange.sprite = noStar;
        } else if (numStar == 1) {
          toChange.sprite = oneStar;
        } else if (numStar == 2) {
          toChange.sprite = twoStar;
        } else if (numStar == 3) {
          toChange.sprite = threeStar;
        }

        changeName.text = toName;

        if (beatLevel < 15) {
          GetComponent < Button > ().onClick.AddListener(ignite);
        } else {
          GetComponent < Button > ().onClick.AddListener(theWM.OpenDesertWorld);
        }
      }
    } else if (world == "Desert") {

    } else if (world == "Snow") {

    } else if (world == "Forest") {

    } else if (world == "Special") {

    }
  }

  private void ignite() {
    theGS.loadScene(beatLevel + 1);
  }
}