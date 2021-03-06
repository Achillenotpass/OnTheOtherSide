﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.HDPipeline;

public class SpeLight : MonoBehaviour
{
    public LightState currentLightState = LightState.Off;
    public MeshRenderer meshRenderer;
    public Material activateLight;
    public Material desactivateLight;
    public DensityVolume densityVolume;

    private Light m_Light;

    [Header("Time between change in the state of the light")]
    public float minTimerForReactivation = 0.05f;
    public float maxTimerForReactivation = 0.2f;

    public float currentTimerForReactivation;

    [Header("Duration of the limited blinking")]
    public float timerForLimitedBlinking = 5;

    public float currentTimerForLimitedBlinking;

    [Header("Do you want the light on at the end ?")]
    public bool stateOfLightForBlinking = true;

    [Header("State of emissive material activate/desactivate")]
    public Color active;
    public Color desactive;

    private void Start()
    {
        m_Light = GetComponent<Light>();
        currentTimerForReactivation = Random.Range(minTimerForReactivation, maxTimerForReactivation);
        currentTimerForLimitedBlinking = timerForLimitedBlinking;
    }

    private void Update()
    {
        if (m_Light.isActiveAndEnabled)
        {
            if(meshRenderer != null)
                meshRenderer.material = activateLight;
        }
        else
        {
            if (meshRenderer != null)
                meshRenderer.material = desactivateLight;
        }

        switch (currentLightState)
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
            m_Light.enabled = true;
        }
    }

    private void LightOff()
    {
        if (m_Light.isActiveAndEnabled)
        {
            m_Light.enabled = false;
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
            currentTimerForReactivation = Random.Range(minTimerForReactivation, maxTimerForReactivation);
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
