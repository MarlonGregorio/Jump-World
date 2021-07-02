using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueManager: MonoBehaviour {

  public bool ignite;
  public GameObject NonClone;
  public int counter;

  private int endCounter;
  private bool toEnd;

  public WindowManager theWM;
  public ScreenFade theSF;
  public GameStats theGS;
  public CameraFollow theCam;
  public Animator theController;
  public Animator thePet;

  [Space]
  public Rigidbody2D cloneRB;
  public Rigidbody2D petRB;

  [Space]
  public Text sideBoxText;
  public TextMesh talkBoxText;
  [Space]
  public Image sideBoxImage;
  public SpriteRenderer talkBoxImage;

  [Space]

  public Text score;
  public Text time;
  public Text coins;

  public GameObject Controls;

  [Space]

  public GameObject shopKeep;
  public Animator shopAnim;
  public Rigidbody2D shopRB;

  [Space]

  public bool igniteSecond;
  public int counterSecond;

  [Space]

  public Animator bossAnime;
  public Rigidbody2D bossRB;

  [Space]

  public Animator copterAnim;
  public Rigidbody2D copterRB;

  [Space]

  public SpriteRenderer bossBox;
  public Sprite equals;
  public Sprite money;

  [Space]

  public SpriteRenderer rescueBox;
  public GameObject rope;

  [Space]

  public GameObject button1;
  public GameObject button2;

  public fadingButton theFB;
  public MusicManager theMM;

  void Start() {

  }

  // Update is called once per frame
  void Update() {

    if (ignite) {
      counter++;

      if (counter == 1) {
        theCam.target = theController.gameObject;
        theController.GetComponent < Animator > ().speed = .5 f;

        Color temp = score.color;
        temp.a = 0;
        score.color = temp;
        time.color = temp;
        coins.color = temp;
        Controls.SetActive(false);
        button1.SetActive(true);
        button2.SetActive(true);
        theFB.canCount = true;
      }

      if (counter == 35) {
        theWM.startMenu.SetActive(false);
        theController.SetInteger("AnimState", 1);

      }

      if (counter >= 50 && counter < 360) {
        cloneRB.velocity = new Vector2(30, 0);
        petRB.velocity = new Vector2(30, 0);
      }

      if (counter == 360) {
        cloneRB.velocity = new Vector2(0, 0);
        petRB.velocity = new Vector2(0, 0);

        theController.SetInteger("AnimState", 0);
        thePet.Play("petIdle");
      }
      if (counter > 360 && counter < 400) {
        Color color = sideBoxImage.color;
        Color colorT = sideBoxText.color;
        colorT.a += .05 f;
        color.a += .05 f;
        if (colorT.a >= 1) {
          color.a = 1;
          colorT.a = 1;
        }
        sideBoxImage.color = color;
        sideBoxText.color = colorT;
      }

      if (counter == 400) {
        theController.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        thePet.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

      }

      if (counter > 400 && counter < 440) {
        Color color = sideBoxImage.color;
        Color colorT = sideBoxText.color;
        colorT.a -= .05 f;
        color.a -= .05 f;
        if (colorT.a <= 0) {
          color.a = 0;
          colorT.a = 0;
          sideBoxText.text = "Good\nLuck";
        }
        sideBoxImage.color = color;
        sideBoxText.color = colorT;
      }

      if (counter == 440) {
        shopKeep.SetActive(true);
      }
      if (counter > 440 && counter < 620) {
        shopRB.velocity = new Vector2(30, 0);
      }
      if (counter == 620) {
        shopRB.velocity = new Vector2(0, 0);
        shopAnim.Play("shopKeepIdle");

      }
      if (counter > 620 && counter < 660) {
        Color color = talkBoxImage.color;
        Color colorT = talkBoxText.color;
        colorT.a += .05 f;
        color.a += .05 f;
        if (colorT.a >= 1) {
          color.a = 1;
          colorT.a = 1;
        }
        talkBoxImage.color = color;
        talkBoxText.color = colorT;
      }
      if (counter > 760 && counter < 800) {
        Color colorT = talkBoxText.color;
        colorT.a -= .05 f;
        if (colorT.a <= 0) {
          colorT.a = 0;
          talkBoxText.text = "Please it's\nbeen 2 whole\ndays!";
        }
        talkBoxText.color = colorT;
      }
      if (counter > 800 && counter < 840) {
        Color colorT = talkBoxText.color;
        colorT.a += .05 f;
        if (colorT.a >= 1) {
          colorT.a = 1;
        }
        talkBoxText.color = colorT;
      }
      if (counter > 940 && counter < 980) {
        Color colorT = talkBoxText.color;
        colorT.a -= .05 f;
        if (colorT.a <= 0) {
          colorT.a = 0;
          talkBoxText.text = "Since I\nlast sold\nanything!";
          thePet.Play("petMad");
        }
        talkBoxText.color = colorT;
      }
      if (counter > 980 && counter < 1020) {
        Color colorT = talkBoxText.color;
        colorT.a += .05 f;
        if (colorT.a >= 1) {
          colorT.a = 1;
        }
        talkBoxText.color = colorT;
      }

      if (counter > 1120 && counter < 1160) {
        Color colorT = talkBoxText.color;
        colorT.a -= .05 f;
        if (colorT.a <= 0) {
          colorT.a = 0;
          talkBoxText.text = "Please!\nPlease!\nPlease!";
        }
        talkBoxText.color = colorT;
      }
      if (counter > 1160 && counter < 1200) {
        Color colorT = talkBoxText.color;
        colorT.a += .05 f;
        if (colorT.a >= 1) {
          colorT.a = 1;
          counter = 1020;
          igniteSecond = true; //this migh cause an issue

        }
        talkBoxText.color = colorT;
        //if () to keep repeating while petnapping hapens
      }
    }

    if (igniteSecond) {
      counterSecond++;

      if (counterSecond == 1) {
        bossRB.gameObject.SetActive(true);
      }

      if (counterSecond < 85) {
        bossRB.velocity = new Vector2(-30, 0);

      }
      if (counterSecond == 85) {
        bossRB.velocity = new Vector2(0, 0);
        bossAnime.Play("bossIdle");

      }

      if (counterSecond > 100 && counterSecond < 140) {
        Color tempColor = bossBox.color;
        tempColor.a += .05 f;
        if (tempColor.a >= 1) {
          tempColor.a = 1;

        }
        bossBox.color = tempColor;
      }

      if (counterSecond == 180) {
        bossBox.sprite = equals;
      }

      if (counterSecond == 220) {
        bossBox.sprite = money;
      }

      if (counterSecond > 260 && counterSecond < 300) {
        Color tempColor = bossBox.color;
        tempColor.a -= .05 f;
        if (tempColor.a <= 0) {
          tempColor.a = 0;

        }
        bossBox.color = tempColor;
      }

      if (counterSecond > 270 && counterSecond < 410) {
        bossRB.velocity = new Vector2(-30, 0);
        bossAnime.Play("BossMainWalk");
      }

      if (counterSecond == 280) {
        thePet.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
      }

      if (counterSecond == 410) {
        thePet.Play("petCaught");
        bossAnime.Play("bossIdle");
        bossRB.velocity = new Vector2(0, 0);
        theMM.slowSwitch(2, 40);
      }

      if (counterSecond == 480) {
        bossAnime.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        rope.SetActive(true);
        bossAnime.Play("BossMainWalk");
      }
      if (counterSecond > 480 && counterSecond <= 960) {
        bossRB.velocity = new Vector2(45, 0);
        petRB.velocity = new Vector2(45, 0);

        if (counterSecond == 960) {
          theCam.target = copterRB.gameObject;
          Destroy(bossRB.gameObject);
          Destroy(petRB.gameObject);
        }
      }

      if (counterSecond == 550) {
        ignite = false;
        counter = 0;
        Color colorT = talkBoxText.color;
        colorT.a = 0;
        talkBoxText.text = "Um did you\nnot just see\nthat?";
        talkBoxText.color = colorT;
      }

      if (counterSecond > 550 && counterSecond < 590) {
        Color colorT = talkBoxText.color;
        colorT.a += .05 f;
        if (colorT.a >= 1) {
          colorT.a = 1;
        }
        talkBoxText.color = colorT;
      }

      if (counterSecond > 690 && counterSecond < 730) {
        Color colorT = talkBoxText.color;
        colorT.a -= .05 f;
        if (colorT.a <= 0) {
          colorT.a = 0;
          talkBoxText.text = "Your friend\nwas just\nkidnapped";
        }
        talkBoxText.color = colorT;
      }

      if (counterSecond > 730 && counterSecond < 770) {
        Color colorT = talkBoxText.color;
        colorT.a += .05 f;
        if (colorT.a >= 1) {
          colorT.a = 1;

        }
        talkBoxText.color = colorT;
      }

      if (counterSecond == 775) {
        theController.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        Color colorT = talkBoxText.color;
        colorT.a = 0;
        talkBoxImage.color = colorT;
        talkBoxText.color = colorT;
        theCam.target = bossAnime.gameObject;
      }

      if (counterSecond > 1000 && counterSecond < 1200) {
        copterRB.velocity = new Vector2(50, 0);
        copterAnim.Play("deathChopperMove");
      }
      if (counterSecond > 1200 && counterSecond < 1500) {
        copterRB.velocity = new Vector2(50, copterRB.velocity.y);
        copterRB.gravityScale = -1;
        copterAnim.Play("deathChopperFly");
      }
      if (counterSecond == 1500) {
        copterRB.velocity = new Vector2(0, 0);
      }

      if (counterSecond > 900 && counterSecond < 1715) {
        theController.SetInteger("AnimState", 1);
        theController.speed = 1;
        cloneRB.velocity = new Vector2(60, 0);
      }
      if (counterSecond == 1715) {
        theController.SetInteger("AnimState", 0);
        theController.speed = 1;
        cloneRB.velocity = new Vector2(0, 0);
      }

      if (counterSecond > 1715 && counterSecond < 1755) {
        Color one = rescueBox.color;
        one.a += .05 f;
        if (one.a >= 1) {
          one.a = 1;
        }
        rescueBox.color = one;
      }

      if (counterSecond > 1835 && counterSecond < 1875) {
        Color one = rescueBox.color;
        one.a -= .05 f;
        if (one.a <= 0) {
          one.a = 0;
        }
        rescueBox.color = one;
      }

      if (counterSecond > 1895) {
        theController.SetInteger("AnimState", 1);
        theController.speed = 1;
        cloneRB.velocity = new Vector2(60, 0);
      }

      if (counterSecond > 1975 && counterSecond < 2015) {
        Color color = sideBoxImage.color;
        Color colorT = sideBoxText.color;
        colorT.a += .05 f;
        color.a += .05 f;
        if (colorT.a >= 1) {
          color.a = 1;
          colorT.a = 1;
        }
        sideBoxImage.color = color;
        sideBoxText.color = colorT;
      }

      if (counterSecond == 2015) {
        endPrologue();
      }
    }

    if (toEnd) {
      endCounter++;
      if (endCounter == 40) {
        theCam.target = NonClone;
        Color temp = score.color;
        Color temp0 = sideBoxText.color;
        temp0.a = 0;
        temp.a = 1;
        score.color = temp;
        time.color = temp;
        coins.color = temp;

        sideBoxImage.color = temp0;
        sideBoxText.color = temp0;

        Controls.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);

        theGS.saveGame();
      }
    }
  }

  public void endPrologue() {
    // theSF.beginFade();
    theGS.loadScene(1);
    theGS.prologueComplete = true;
    toEnd = true;
  }
}