using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerSoundEffect : Activable
{
    public AudioSource m_AudioSource;
    public List<AudioClip> soundEffects;

    public override void Interaction()
    {
        m_AudioSource.PlayOneShot(soundEffects[Random.Range(0, soundEffects.Count)]);
    }
}
