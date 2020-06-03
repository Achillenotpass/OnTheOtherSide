using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSimonDoor : Activable
{
    public List<Activable> toActivateWhenBroken;

    public int numberOfHitToDestroy = 3;
    private int m_CurrentNumberOfHit = 0;

    private bool m_IsDestroyed = false;

    private AudioSource m_AudioSource;
    public AudioClip hitSound;
    public AudioClip destroyedSound;

    private Animator m_Animator;


    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_Animator = GetComponent<Animator>();
    }

    public override void Interaction()
    {
        if (!m_IsDestroyed)
        {
            Hit();
        }
    }

    void Hit()
    {
        m_CurrentNumberOfHit = m_CurrentNumberOfHit + 1;
        if (m_CurrentNumberOfHit == numberOfHitToDestroy)
        {
            Destroyed();
        }
        else
        {
            m_Animator.SetTrigger("Hit");
            m_AudioSource.PlayOneShot(hitSound);
        }
    }

    void Destroyed()
    {
        m_Animator.SetBool("Destroyed", true);
        m_AudioSource.PlayOneShot(destroyedSound);

        m_IsDestroyed = true;
        foreach (Activable toActivate in toActivateWhenBroken)
        {
            toActivate.Interaction();
        }
    }
}
