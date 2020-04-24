using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInterruptor : Activable
{
    public List<SpeLight> m_LightScripts;

    
    public override void Interaction()
    {
        foreach (SpeLight light in m_LightScripts)
        {
            if (light.currentLightState == LightState.On)
                light.currentLightState = LightState.Off;
            else if (light.currentLightState == LightState.Off)
                light.currentLightState = LightState.On;
        }
    }

}
