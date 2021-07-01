using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController: MonoBehaviour {

  private AudioSource theAudio;
  private float audioLevel;
  public float defaultAudioLevel;

  // Use this for initialization
  void Start() {
    theAudio = GetComponent < AudioSource > ();
  }

  // Update is called once per frame
  void Update() {

  }

  public void SetAudioLevel(float volume) {
    if (theAudio == null) {
      theAudio = GetComponent < AudioSource > ();
    }

    audioLevel = defaultAudioLevel * volume;
    theAudio.volume = audioLevel;
  }
}