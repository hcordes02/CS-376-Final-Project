using UnityEngine;

/// <summary>
/// Sound controller
/// </summary>
public class SoundManager : MonoBehaviour
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
