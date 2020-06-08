using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableDoor : Activable
{
    public AudioSource m_AudioSource;
    public AudioClip lockedDoor;

    
    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public override void Interaction()
    {
        m_AudioSource.PlayOneShot(lockedDoor);
    }
}
