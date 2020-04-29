using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangementsMultiplesLumières : Activable
{
    public List<SpeLight> lightScripts;

    public LightState firstState;
    public LightState secondState;

    [Header("This array contains the time (in secondes) between the 2 states")]
    public float timeBetweenLightStates;

    public override void Interaction()
    {
        foreach (SpeLight light in lightScripts)
        {
            light.currentLightState = firstState;
        }
        Invoke("SecondState", timeBetweenLightStates);
    }

    private void SecondState()
    {
        foreach (SpeLight light in lightScripts)
        {
            light.currentLightState = secondState;
        }
    }
}
