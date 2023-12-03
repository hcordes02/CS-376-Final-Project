using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{

    public AudioSource blast_sound;
    public void Play_Fire()
    {
        blast_sound.Play();
    }

    public AudioSource hit_sound;
    public void Play_Hit()
    {
        hit_sound.Play();
    }

    public AudioSource power_sound;
    public void Play_Death()
    {
        power_sound.Play();
    }

}
