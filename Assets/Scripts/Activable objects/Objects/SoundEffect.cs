using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : Activable
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public override void Interaction()
    {
        source.PlayOneShot(source.clip);
    }
}
