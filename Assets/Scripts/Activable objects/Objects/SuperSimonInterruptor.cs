using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSimonInterruptor : Activable
{
    public SuperSimon superSimon;
    private Animator m_Animator;

    private bool m_CanBeActivated = true;
    private float m_ReactivationTimer = 1.5f;
    private float m_CurrentReactivationTimer = 0.0f;

    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (m_CurrentReactivationTimer <= 0.0f && !m_CanBeActivated)
        {
            m_CanBeActivated = true;
        }
        else
        {
            m_CurrentReactivationTimer = m_CurrentReactivationTimer - Time.deltaTime;
        }
        if (m_CanBeActivated)
        {
            gameObject.tag = "Activable";
        }
        else
        {
            gameObject.tag = "Untagged";
        }
    }

    public override void Interaction()
    {
        if (m_CanBeActivated)
        {
            m_AudioSource.Play();
            m_CanBeActivated = false;
            m_CurrentReactivationTimer = m_ReactivationTimer;

            superSimon.superSimonList.Add(this);
            superSimon.Interaction();
            m_Animator.SetTrigger("Activated");
        }
    }
}