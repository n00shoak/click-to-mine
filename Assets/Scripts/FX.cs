using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    [Header("sound to play")]
    public AudioSource audSource;

    [Header("particle to play")]
    public ParticleSystem prtSource;

    public void playParticle()
    {
        prtSource.Play();
    }

    public void playAudio()
    {
        audSource.Play();
        Debug.Log("CACa");
    }
}
