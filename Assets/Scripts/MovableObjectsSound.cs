﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectsSound : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip collisionSound;
    // Start is called before the first frame update
    void Awake()
    {
        m_AudioSource = gameObject.AddComponent<AudioSource>();
        m_AudioSource.spatialBlend = 1;
        m_AudioSource.clip = collisionSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_AudioSource.pitch = Random.Range(0.7f, 1.2f);
        m_AudioSource.Play();
    }
}