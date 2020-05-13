using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDoor : Activable
{
    public override void Interaction()
    {
        transform.Translate(0.0f, - transform.localScale.y / 3, 0.0f);
    }
}
