using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public bool musicCanPlay;
    public VolumeManager theVM;


    public AudioSource[] musicTracks;

    public int currentTrack;

    private int currentDelay;
    private int toSwitch;
    private int counter;
    private bool ignite;


	void Start () {
		
	}
	


	void Update () {


        if(ignite)
        {
            counter++;
            if(counter==currentDelay)
            {
                musicCanPlay = false;
                
                theVM.slowlyHigher();
                
            }

            if(counter == currentDelay + 30)
            {
                musicCanPlay = true;
                SwitchTrack(toSwitch);
                ignite = false;
                counter = 0;
            }
        }






		if(musicCanPlay)
        {
            if(!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        }
        else
        {
            musicTracks[currentTrack].Stop();
        }
	}

    public void SwitchTrack(int newTrack)
    {
        //if (newTrack != currentTrack)
       // {
            musicTracks[currentTrack].Stop();
            currentTrack = newTrack;
            musicTracks[currentTrack].Play();
       // }
               
    }

    public void slowSwitch(int newTrack, int delay)
    {
        currentDelay = delay;
        toSwitch = newTrack;
        ignite = true;

        theVM.slowlyLower();

    }
}
