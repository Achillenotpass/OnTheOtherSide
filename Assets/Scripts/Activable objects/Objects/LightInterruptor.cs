using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInterruptor : Activable
{
    public GameObject lightToActivate;

    private SpeLight m_LightScript;

    private void Awake()
    {
        m_LightScript = lightToActivate.GetComponent<SpeLight>();
    }

    public override void Interaction()
    {
        if (m_LightScript.currentLightState == LightState.On)
            m_LightScript.currentLightState = LightState.Off;
        else if (m_LightScript.currentLightState == LightState.Off)
            m_LightScript.currentLightState = LightState.On;
    }

}
