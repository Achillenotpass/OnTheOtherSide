using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnStart : MonoBehaviour
{
    public List<Activable> toActivate;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Activable toActivate in toActivate)
        {
            toActivate.Interaction();
        }
    }
}
