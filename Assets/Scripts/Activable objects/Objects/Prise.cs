using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prise : Activable
{
    private bool isOn = true;

    public override void Interaction()
    {
        isOn = !isOn;

        switch (isOn)
        {
            case true:
                transform.Rotate(30.0f, 0.0f, 0.0f);
                break;

            case false:
                transform.Rotate(-30.0f, 0.0f, 0.0f);
                break;
        }

    }

}
