using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDoor : Activable
{
    public override void Interaction()
    {
        transform.Translate(0.0f, 0.0f, -1.2f);
    }
}
