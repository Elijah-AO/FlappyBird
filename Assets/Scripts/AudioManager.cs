using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Whoosh;
    public AudioSource Slap;
    public AudioSource score;
    // Start is called before the first frame update
    public void PlayWhoosh()
    {
        Whoosh.Play();
    }
    public void PlaySlap()
    {
        Slap.Play();
    }
    public void PlayScore()
    {
        score.Play();
    }
    public void MuteAllSounds(bool mute)
        {
            Whoosh.mute = mute;
            Slap.mute = mute;
            score.mute = mute;
        }
    public void UnmuteAllSounds(){
        MuteAllSounds(false);
    }
}