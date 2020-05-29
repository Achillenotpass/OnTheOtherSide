using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MovableObjectsSound : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public AudioClip collisionSound;

    private Player m_Player;

    void Awake()
    {
        m_Player = FindObjectOfType<Player>();
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        m_AudioSource.clip = collisionSound;
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        m_AudioSource.pitch = Random.Range(0.85f, 1.15f);
        m_AudioSource.Play();
    }
}
