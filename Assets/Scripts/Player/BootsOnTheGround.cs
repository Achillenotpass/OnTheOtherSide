using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsOnTheGround : MonoBehaviour
{
    public AudioSource audioSource;

    void PlaySound()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }
}
