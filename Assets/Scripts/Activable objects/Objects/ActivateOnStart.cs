using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnStart : MonoBehaviour
{
    public bool delayedActivation = false;
    public float timeBeforeDelayedActivation;
    public List<Activable> toActivate;

    // Start is called before the first frame update
    void Start()
    {
        if (!delayedActivation)
        {
            foreach (Activable toActivate in toActivate)
            {
                toActivate.Interaction();
            }
        }
        else
        {
            Invoke("DelayedActivation", timeBeforeDelayedActivation);
        }
        
    }

    public void DelayedActivation()
    {
        foreach (Activable toActivate in toActivate)
        {
            toActivate.Interaction();
        }
    }
}
