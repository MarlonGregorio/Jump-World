using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

 
    public AudioSource menuClick;

    public AudioSource pause;

    public AudioSource unPause;

    public AudioSource coin;

    public AudioSource hitblock;

    public AudioSource jump;

    public AudioSource stomp;

    public AudioSource powerUp;

    public AudioSource scoreCount;

    public AudioSource ding;

    public AudioSource ding2;

    public AudioSource ding3;

    public AudioSource endLevel;

    public AudioSource death;

    public AudioSource punch;

    public AudioSource blast;

    public AudioSource checkPoint;




    public void soundMenuClick()
    {
        menuClick.Play();
    }

    public void PlaySound(string x)
    {
        if (x == "MenuClick")
        {
            menuClick.Play();
        }
        if (x == "Coin")
        {
            coin.Play();
        }
        if (x == "HitBlock")
        {
            hitblock.Play();
        }

        if (x == "Jump")
        {
            jump.Play();
        }

        if (x == "Stomp")
        {
            stomp.Play();
        }  

        if (x == "PowerUp")
        {
            powerUp.Play();
        }

        if (x == "Pause")
        {
            pause.Play();
        }
        if (x == "UnPause")
        {
            unPause.Play();
        }
        if (x == "ScoreCount")
        {
            scoreCount.Play();
        }
        if (x == "Ding1")
        {
            ding.Play();
        }
        if (x == "Ding2")
        {
            ding2.Play();
        }
        if (x == "Ding3")
        {
            ding3.Play();
        }
        if (x == "EndLevel")
        {
            endLevel.Play();
        }

        if (x == "Death")
        {
            death.Play();
        }

        if (x == "Punch")
        {
            punch.Play();
        }

        if (x == "Blast")
        {
            blast.Play();
        }


        if (x=="StopScore")
        {
            scoreCount.Stop();
        }

        if (x == "CheckPoint")
        {
            checkPoint.Play();
        }
    }
}
