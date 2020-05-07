using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInterruptor : Activable
{
    private AudioSource m_AudioSource;

    public List<SpeLight> m_LightScripts;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }


    public override void Interaction()
    {
        m_AudioSource.Play();
        foreach (SpeLight light in m_LightScripts)
        {
            if (light.currentLightState == LightState.On)
                light.currentLightState = LightState.Off;
            else if (light.currentLightState == LightState.Off)
                light.currentLightState = LightState.On;
        }
    }

}
