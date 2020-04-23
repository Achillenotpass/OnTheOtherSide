using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeLight : MonoBehaviour
{
    public LightState currentLightState = LightState.Off;

    private Light m_Light;

    public float timerForReactivation = 1;

    public float currentTimerForReactivation;

    private void Start()
    {
        m_Light = GetComponent<Light>();
        currentTimerForReactivation = timerForReactivation;
    }

    private void Update()
    {
        switch(currentLightState)
        {
            case LightState.On:
                LightOn();
                break;
            case LightState.Off:
                LightOff();
                break;
            case LightState.Blinking:
                LightBlinking();
                break;
        }
    }

    private void LightOn()
    {
        if(!m_Light.isActiveAndEnabled)
        {
            m_Light.enabled = !m_Light.enabled;
        }
    }

    private void LightOff()
    {
        if (m_Light.isActiveAndEnabled)
        {
            m_Light.enabled = !m_Light.enabled;
        }
    }

    private void LightBlinking()
    {
        if(currentTimerForReactivation > 0)
        {
            currentTimerForReactivation -= 1 * Time.deltaTime;
        }
        else
        {
            Blinking();
            currentTimerForReactivation = timerForReactivation;
        }
    }

    private void Blinking()
    {
        m_Light.enabled = !m_Light.enabled;
    }
}

public enum LightState
{
    On,
    Off,
    Blinking,
}
