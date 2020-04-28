using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activable
{
    //SoundEffects
    public AudioClip lockedDoor;
    public AudioClip openingDoor;
    public AudioClip closingDoor;
    private AudioSource m_AudioSource;

    public bool isOpen = false;
    public bool isLeftDoor = false;
    private Vector3 baseRotation;

    public bool isLocked = false;

    // Start is called before the first frame update
    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();

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
        if (!isLocked)
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                m_AudioSource.PlayOneShot(openingDoor);
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
                m_AudioSource.PlayOneShot(closingDoor);
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation));
            }
        }
        else
        {
            m_AudioSource.PlayOneShot(lockedDoor);
        }
    }
}
