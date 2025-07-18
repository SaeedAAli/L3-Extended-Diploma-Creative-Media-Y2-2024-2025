using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource AudioPlayer;
    public AudioSource SoundEffectPlayer;


    public AudioClip backgroundmusic;
    public AudioClip death;
    public AudioClip CoinCollector;
    public AudioClip PlatformDestroy;

    // Start is called before the first frame update
    void Start()
    {
        AudioPlayer.clip = backgroundmusic;
        AudioPlayer.Play();
    }

    public void Stop()
    {
        if(AudioPlayer.isPlaying)
        {
            AudioPlayer.Stop();
        }
    }

}

 