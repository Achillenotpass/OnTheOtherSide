﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBlinkingLight : MonoBehaviour
{
    private CurveMonsterLight curveMonsterLight;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Light>() != null)
        {
            if(other.gameObject.GetComponent<SpeLight>().currentLightState == LightState.On)
            other.gameObject.GetComponent<SpeLight>().currentLightState = LightState.Blinking;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Light>() != null)
        {
            float distanceLightMonster = Vector3.Distance(transform.position, other.gameObject.transform.position);
            curveMonsterLight = GetComponent<CurveMonsterLight>();
            curveMonsterLight.ApplyBlinking(other.gameObject.GetComponent<SpeLight>(), distanceLightMonster);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Light>() != null)
        {
            other.gameObject.GetComponent<SpeLight>().currentLightState = LightState.On;
        }
    }
}
