using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugActivables : Activable
{
    public override void Interaction()
    {
        Debug.Log("Je suis un object activable fonctionnel");
    }
}
