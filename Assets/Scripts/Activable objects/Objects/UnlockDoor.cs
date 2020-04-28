using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : Activable
{
    public Door[] doors;

    [Header("Do you want to unlock the doors ?")]
    public bool unlock = true;

    public override void Interaction()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            switch(unlock)
            {
                case true:
                    doors[i].isLocked = false;
                    break;
                case false:
                    doors[i].isLocked = true;
                    break;
            }
        }
    }
}
