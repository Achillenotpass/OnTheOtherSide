using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHolder : Activable
{
    public int numberOfTargets;
    private int activatedTargets;


    public GameObject[] toActivate;


    


    public override void Interaction()
    {
        activatedTargets = activatedTargets + 1;

        if (activatedTargets == numberOfTargets)
        {
            for (int i = 0; i < toActivate.Length; i++)
            {
                toActivate[i].GetComponent<Activable>().Interaction();
            }
        }
    }
}
