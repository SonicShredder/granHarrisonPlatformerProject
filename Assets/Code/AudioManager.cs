using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioSource sfx;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    public static void PlaySoundEffect(AudioClip sound)
    {
        sfx.PlayOneShot(sound);
    }
      
}
