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



    private void Awake()
    {
        m_FpsCamera = GetComponent<Camera>();
    }
    
    void Update()
    {
       

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
        }
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
                    m_ObjectHeld = hitInfo.transform.gameObject;
                    //We set the target of the held object to the current position of the held object
                    targetHeldObject.transform.position = m_ObjectHeld.transform.position;

                    //We also get the object's rigidbody to disable gravity
                    m_ObjectHeldRigidbody = m_ObjectHeld.GetComponent<Rigidbody>();
                    m_ObjectHeldRigidbody.useGravity = false;
                }
            }
        }

        //Dropping a held object
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //If the player holds an object
            if (m_ObjectHeld != null)
            {
                //We activate gravity again
                m_ObjectHeldRigidbody.useGravity = true;

                m_ObjectHeldRigidbody.AddForce((2 * m_HeldObjectCurrentPosition - m_HeldObjectPastPosition) * Time.deltaTime);

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

                //The player is not holding anything
                m_ObjectHeld = null;
                m_ObjectHeldRigidbody = null;
            }
        }
    }

    private void UpdateHeldObjectPosition()
    {
        //If the player holds an object
        if (m_ObjectHeld != null)
        {
            //We actualize the held object's position with a lerp. It tries to reach the position of a gameobject that is parented to the player
            m_ObjectHeld.transform.position = Vector3.Lerp(m_ObjectHeld.transform.position, targetHeldObject.transform.position, 0.1f);

            m_HeldObjectPastPosition = m_HeldObjectCurrentPosition;
            m_HeldObjectCurrentPosition = m_ObjectHeld.transform.position;
        }
    }
}
