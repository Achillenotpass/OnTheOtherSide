using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will allow the player to activate activable object (interruptors...), end to hold and release movable objects.
public class Interaction : MonoBehaviour
{
    private Camera m_FpsCamera = null;

    public float maxInteractionDistance= 1.5f;

    public GameObject targetHeldObject = null;
    private GameObject m_ObjectHeld = null;
    private Rigidbody m_ObjectHeldRigidbody = null;

    public float throwingForce = 1000.0f;

    //For the inertia of the object
    private Vector3 m_HeldObjectPastPosition = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 m_HeldObjectCurrentPosition = new Vector3(0.0f, 0.0f, 0.0f);

    //UI pointer
    public GameObject usualPointer;
    public GameObject activablePointer;
    public GameObject movablePointer;
    public GameObject movableHeldPointer;
    public GameObject letterPointer;

    private PointerState pointerState = PointerState.Usual;

    private void Awake()
    {
        m_FpsCamera = GetComponent<Camera>();
    }
    
    void Update()
    {
        UpdateHeldObjectPosition();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hitInfo;
            //Activating an activable object when pressing left-click
            if (Physics.Raycast(m_FpsCamera.transform.position, m_FpsCamera.transform.forward, out hitInfo, maxInteractionDistance))
            {
                //We check if the object is activable
                if (hitInfo.transform.gameObject.tag == "Activable")
                {
                    //If it is, we activate his "Interaction" function
                    hitInfo.transform.gameObject.GetComponent<Activable>().Interaction();
                }

                //Getting hold of a movable object when pressing left-click
                else if (hitInfo.transform.gameObject.tag == "Movable")
                {
                    //We get the object
                    m_ObjectHeld = hitInfo.transform.gameObject;

                    //m_ObjectHeld.transform.SetParent(transform);
                    //We set the target and rotation of the held object to the current position  and rotation of the held object
                    targetHeldObject.transform.position = m_ObjectHeld.transform.position;
                    targetHeldObject.transform.rotation = m_ObjectHeld.transform.rotation;

                    //We also get the object's rigidbody to disable gravity
                    m_ObjectHeldRigidbody = m_ObjectHeld.GetComponent<Rigidbody>();
                    m_ObjectHeldRigidbody.useGravity = false;
                }
            }
        }
        UpdatePointerData();
        UpdatePointerImage();

        //Dropping a held object
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //If the player holds an object
            if (m_ObjectHeld != null)
            {
                //We activate gravity again
                m_ObjectHeldRigidbody.useGravity = true;

                //We unparent the object
                //m_ObjectHeld.transform.SetParent(null);

                m_ObjectHeld = null;
                m_ObjectHeldRigidbody = null;

            }
        }

        //Throwing a held object forward when pressing right-click
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //If the player holds an object
            if (m_ObjectHeld != null)
            {
                //We activate gravity again
                m_ObjectHeldRigidbody.useGravity = true;
                //And we add a force to the object to throw it away
                m_ObjectHeldRigidbody.AddForce(m_FpsCamera.transform.forward * throwingForce * Time.deltaTime);

                //We unparent the object
                //m_ObjectHeld.transform.SetParent(null);

                //The player is not holding anything
                m_ObjectHeld = null;
                m_ObjectHeldRigidbody = null;
            }
        }
    }

    private void UpdatePointerData()
    {
        RaycastHit hitInfo;
        if (m_ObjectHeld != null)
        {
            pointerState = PointerState.Held;
        }
        else if (Physics.Raycast(m_FpsCamera.transform.position, m_FpsCamera.transform.forward, out hitInfo, maxInteractionDistance))
        {
            if (hitInfo.transform.gameObject.tag == "Activable")
            {
                if (hitInfo.transform.gameObject.GetComponent<Letter>() != null)
                {
                    pointerState = PointerState.Letter;
                }
                else if (hitInfo.transform.gameObject.GetComponent<Door>() != null)
                {
                    pointerState = PointerState.Movable;
                }
                else
                {
                    pointerState = PointerState.Activable;
                }
            }
            else if (hitInfo.transform.gameObject.tag == "Movable")
            {
                pointerState = PointerState.Movable;
            }
            else
            {
                pointerState = PointerState.Usual;
            }
        }
        else
        {
            pointerState = PointerState.Usual;
        }
    }

    private void UpdatePointerImage()
    {
        switch (pointerState)
        {
            case PointerState.Usual:
                usualPointer.SetActive(true);
                activablePointer.SetActive(false);
                movablePointer.SetActive(false);
                movableHeldPointer.SetActive(false);
                letterPointer.SetActive(false);
                break;
            case PointerState.Activable:
                usualPointer.SetActive(false);
                activablePointer.SetActive(true);
                movablePointer.SetActive(false);
                movableHeldPointer.SetActive(false);
                letterPointer.SetActive(false);
                break;
            case PointerState.Movable:
                usualPointer.SetActive(false);
                activablePointer.SetActive(false);
                movablePointer.SetActive(true);
                movableHeldPointer.SetActive(false);
                letterPointer.SetActive(false);
                break;
            case PointerState.Held:
                usualPointer.SetActive(false);
                activablePointer.SetActive(false);
                movablePointer.SetActive(false);
                movableHeldPointer.SetActive(true);
                letterPointer.SetActive(false);
                break;
            case PointerState.Letter:
                usualPointer.SetActive(false);
                activablePointer.SetActive(false);
                movablePointer.SetActive(false);
                movableHeldPointer.SetActive(false);
                letterPointer.SetActive(true);
                break;
        }
    }

    private void UpdateHeldObjectPosition()
    {
        //If the player holds an object
        if (m_ObjectHeld != null)
        {
            //We actualize the hekd objects rotations
            m_ObjectHeld.transform.rotation = targetHeldObject.transform.rotation;
            //We actualize the held object's position with a lerp. It tries to reach the position of a gameobject that is parented to the player
            m_ObjectHeld.transform.position = Vector3.Lerp(m_ObjectHeld.transform.position, targetHeldObject.transform.position, 0.7f);
        }
    }
}

public enum PointerState
{
    Usual,
    Activable,
    Movable,
    Held,
    Letter,
}