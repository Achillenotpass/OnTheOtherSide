using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSimonInterruptor : Activable
{
    public SuperSimon superSimon;
    public override void Interaction()
    {
        superSimon.superSimonList.Add(this);
    }
}
