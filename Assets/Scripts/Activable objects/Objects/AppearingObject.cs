using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingObject : Activable
{
    public GameObject[] objectToAppear;

    public override void Interaction()
    {
        for(int i = 0; i < objectToAppear.Length; i++)
            objectToAppear[i].SetActive(true);
    }
}
