using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDoor : Activable
{
    public AudioClip downSound;
    public AudioClip finalDownSound;
    private AudioSource m_AudioSource;

    private int m_InteractionNumber = 0;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }


    public override void Interaction()
    {
        transform.Translate(0.0f, 0.0f, -1.2f);


        m_InteractionNumber = m_InteractionNumber + 1;
        if (m_InteractionNumber == 3)
        {
            m_AudioSource.PlayOneShot(finalDownSound);
        }
        else
        {
            m_AudioSource.PlayOneShot(downSound);
        }
    }
}
