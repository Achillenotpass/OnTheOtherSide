﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoors : MonoBehaviour
{//PORTES
    public float hittingDoorTimer;
    public float m_CurrentHittingDoorTimer = 0.0f;

    
    void Update()
    {
        m_CurrentHittingDoorTimer = m_CurrentHittingDoorTimer + Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.GetComponent<Door>() != null)
        {
            Debug.Log("door");
            AttackDoor(other.gameObject.GetComponent<Door>());
        }
    }

    public void AttackDoor(Door door)
    {
        if (m_CurrentHittingDoorTimer >= hittingDoorTimer)
        {
            Debug.Log("timer");
            m_CurrentHittingDoorTimer = 0.0f;
            door.health = door.health - 1;
        }
    }
}