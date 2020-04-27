using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activable
{
    public bool isOpen = false;
    public bool isLeftDoor = false;
    private Vector3 baseRotation;

    public bool isLocked = false;

    // Start is called before the first frame update
    void Awake()
    {
        baseRotation = transform.rotation.eulerAngles;

        if (isOpen)
        {
            if (isLeftDoor)
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, 90.0f, 0.0f)));
            }
            else
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, -90.0f, 0.0f)));
            }
        }
        else
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation));
        }
    }
    


    public override void Interaction()
    {
        isOpen = !isOpen;

        if (!isLocked)
        {
            if (isOpen)
            {
                if (isLeftDoor)
                {
                    transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, 90.0f, 0.0f)));
                }
                else
                {
                    transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, -90.0f, 0.0f)));
                }
            }
            else
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation));
            }
        }
    }
}
