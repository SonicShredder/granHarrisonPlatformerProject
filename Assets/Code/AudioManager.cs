using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource music;
    public static AudioSource sfx;

    public static float musicTimeStamp;

    private void Start()
    {
        AudioSource[] children = gameObject.GetComponentsInChildren<AudioSource>();
        music = children[0];
        sfx= children[1];

        music.time = musicTimeStamp;
        music.Play();
    }

    public static void PlaySoundEffect(AudioClip sound, float volume)
    {
       sfx.PlayOneShot(sound, volume);
    }


}
