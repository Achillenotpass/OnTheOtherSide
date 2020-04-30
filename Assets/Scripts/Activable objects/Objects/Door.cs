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

    private CurveRotation m_CurveRotation;

    public AnimationCurve openingLeft;
    public AnimationCurve openingRight;

    public AnimationCurve endingLeft;
    public AnimationCurve endingRight;

    public AnimationCurve begingOpenedLeft;
    public AnimationCurve begingOpenedRight;


    // Start is called before the first frame update
    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();

        baseRotation = transform.rotation.eulerAngles;

        m_CurveRotation = GetComponent<CurveRotation>();

        if (isOpen)
        {
            if (isLeftDoor)
            {

                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, 90.0f, 0.0f)));
                m_CurveRotation.axeY = begingOpenedLeft;
            }
            else
            {
                transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, -90.0f, 0.0f)));
                m_CurveRotation.axeY = begingOpenedRight;
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
                if (isLeftDoor)
                {
                    //transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, 90.0f, 0.0f)));
                    m_CurveRotation.axeY = openingLeft;
                    m_CurveRotation.BeginMovement();
                }
                else
                {
                    //transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, -90.0f, 0.0f)));
                    m_CurveRotation.axeY = openingRight;
                    m_CurveRotation.BeginMovement();
                }
                m_AudioSource.PlayOneShot(openingDoor);
            }
            else
            {
                if(isLeftDoor)
                {
                    m_CurveRotation.axeY = endingLeft;
                    m_CurveRotation.BeginMovement();
                }
                else
                {
                    m_CurveRotation.axeY = endingRight;
                    m_CurveRotation.BeginMovement();
                }
                m_AudioSource.PlayOneShot(closingDoor);
                //transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation));
            }
        }
        else
        {
            m_AudioSource.PlayOneShot(lockedDoor);
        }
    }
}
