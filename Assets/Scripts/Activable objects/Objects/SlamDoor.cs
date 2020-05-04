using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamDoor : Activable
{
    public Door[] doors;

    [Header("Do you want to open the doors ?")]
    public bool openning = true;

    public override void Interaction()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            switch (openning)
            {
                case true:
                    switch(doors[i].isLeftDoor)
                    {
                        case true:
                            doors[i].curveRotation.axeY = doors[i].slamOpeningLeft;
                            doors[i].curveRotation.BeginMovement();
                            doors[i].isOpen = true;
                            break;
                        case false:
                            doors[i].curveRotation.axeY = doors[i].slamOpeningRight;
                            doors[i].curveRotation.BeginMovement();
                            doors[i].isOpen = true;
                            break;
                    }
                    doors[i].m_AudioSource.PlayOneShot(doors[i].openingDoor);
                    break;
                case false:
                    switch (doors[i].isLeftDoor)
                    {
                        case true:
                            doors[i].curveRotation.axeY = doors[i].slamEndingLeft;
                            doors[i].curveRotation.BeginMovement();
                            doors[i].isOpen = false;
                            break;
                        case false:
                            doors[i].curveRotation.axeY = doors[i].slamEndingRight;
                            doors[i].curveRotation.BeginMovement();
                            doors[i].isOpen = false;
                            break;
                    }
                    doors[i].m_AudioSource.PlayOneShot(doors[i].closingDoor);
                    break;
            }
        }
    }
}
