using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSimonPattern : MonoBehaviour
{
    public GameObject[] lightingObjects;
    public SuperSimonColors[] lightingPatternToShow;
    private int m_CurrentIndex = 0;

    private GameObject m_LastLightedObject;

    public Material baseMaterial;
    public Material blueMaterial;
    public Material greenMaterial;
    public Material yellowMaterial;
    public Material pinkMaterial;

    public float timeBetweenLights;
    public float timeBetweenPatterns;
    public float lightingTime;
    private float m_CurrentTimer = 0.0f;

    private PatternState m_CurrentPatternState = PatternState.betweenPatterns;

    // Start is called before the first frame update
    void Start()
    {
        m_CurrentTimer = timeBetweenPatterns;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_CurrentPatternState)
        {
            case PatternState.lightOn:
                if (m_CurrentTimer < lightingTime)
                {
                    m_CurrentTimer = m_CurrentTimer + Time.deltaTime;
                }
                else
                {
                    m_CurrentIndex = m_CurrentIndex + 1;
                    if (m_CurrentIndex == lightingPatternToShow.Length)
                    {
                        m_CurrentPatternState = PatternState.betweenPatterns;
                        m_CurrentTimer = 0.0f;
                        m_CurrentIndex = 0;
                        TurnLightOff();
                    }
                    else
                    {
                        m_CurrentPatternState = PatternState.lightOff;
                        m_CurrentTimer = 0.0f;
                        TurnLightOff();
                    }
                }
                break;

            case PatternState.lightOff:
                if (m_CurrentTimer < timeBetweenLights)
                {
                    m_CurrentTimer = m_CurrentTimer + Time.deltaTime;
                }
                else
                {
                    m_CurrentPatternState = PatternState.lightOn;
                    m_CurrentTimer = 0.0f;
                    TurnLightOn(lightingObjects[Random.Range(0, lightingObjects.Length)], lightingPatternToShow[m_CurrentIndex]);
                }
                break;

            case PatternState.betweenPatterns:
                if (m_CurrentTimer < timeBetweenPatterns)
                {
                    m_CurrentTimer = m_CurrentTimer + Time.deltaTime;
                }
                else
                {
                    m_CurrentPatternState = PatternState.lightOn;
                    m_CurrentTimer = 0.0f;
                    TurnLightOn(lightingObjects[m_CurrentIndex], lightingPatternToShow[m_CurrentIndex]);
                }
                break;
        }
    }


    public void TurnLightOn(GameObject objectToLight, SuperSimonColors color)
    {
        m_LastLightedObject = objectToLight;
        switch (color)
        {
            case SuperSimonColors.Bleu:
                objectToLight.GetComponent<MeshRenderer>().material = blueMaterial;
                break;
            case SuperSimonColors.Vert:
                objectToLight.GetComponent<MeshRenderer>().material = greenMaterial;
                break;
            case SuperSimonColors.Jaune:
                objectToLight.GetComponent<MeshRenderer>().material = yellowMaterial;
                break;
            case SuperSimonColors.Rose:
                objectToLight.GetComponent<MeshRenderer>().material = pinkMaterial;
                break;
        }
    }

    public void TurnLightOff()
    {
        m_LastLightedObject.GetComponent<MeshRenderer>().material = baseMaterial;
    }
}


public enum SuperSimonColors
{
    Bleu,
    Vert,
    Jaune,
    Rose,
}

public enum PatternState
{
    lightOn,
    lightOff,
    betweenPatterns,
}
