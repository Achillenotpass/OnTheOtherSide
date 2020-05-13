using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingObject : Activable
{
    public GameObject[] objectToAppear;
    public GameObject[] objectToDisappear;

    public override void Interaction()
    {
        for (int i = 0; i < objectToAppear.Length; i++)
        {
            Debug.Log("appear");
            objectToAppear[i].SetActive(true);
        }

        for (int i = 0; i < objectToDisappear.Length; i++)
        {
            Debug.Log("disappear");
            objectToAppear[i].SetActive(false);
        }
    }
}
