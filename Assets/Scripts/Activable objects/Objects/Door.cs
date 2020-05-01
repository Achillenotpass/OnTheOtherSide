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

    [SerializeField]
    public CurveRotation curveRotation;

    public AnimationCurve openingLeft;
    public AnimationCurve openingRight;

    public AnimationCurve endingLeft;
    public AnimationCurve endingRight;

    public AnimationCurve begingOpenedLeft;
    public AnimationCurve begingOpenedRight;

    public AnimationCurve slamOpeningLeft;
    public AnimationCurve slamOpeningRight;

    public AnimationCurve slamEndingLeft;
    public AnimationCurve slamEndingRight;

    // Start is called before the first frame update
    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();

        baseRotation = transform.rotation.eulerAngles;
        Debug.Log(transform.rotation.eulerAngles);

        curveRotation = GetComponent<CurveRotation>();

        if (isOpen)
        {
            if (isLeftDoor)
            {

                //transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, 90.0f, 0.0f)));
                curveRotation.axeY = begingOpenedLeft;
            }
            else
            {
                //transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, -90.0f, 0.0f)));
                curveRotation.axeY = begingOpenedRight;
            }
        }
        else
        {
            //transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation));
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
                    curveRotation.axeY = openingLeft;
                    curveRotation.BeginMovement();
                }
                else
                {
                    //transform.SetPositionAndRotation(transform.position, Quaternion.Euler(baseRotation + new Vector3(0.0f, -90.0f, 0.0f)));
                    curveRotation.axeY = openingRight;
                    curveRotation.BeginMovement();
                }
                m_AudioSource.PlayOneShot(openingDoor);
            }
            else
            {
                if(isLeftDoor)
                {
                    curveRotation.axeY = endingLeft;
                    curveRotation.BeginMovement();
                }
                else
                {
                    curveRotation.axeY = endingRight;
                    curveRotation.BeginMovement();
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
