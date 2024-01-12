using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndSFXController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] currentClip;

    public void ChangeClip(AudioClip clip, bool loop)
    {
        audioSource.Stop();
        audioSource.loop = loop;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
