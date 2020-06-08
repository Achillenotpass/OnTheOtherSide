using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Bending : MonoBehaviour
{
    public Camera playerCamera;

    private Player m_PlayerScript;

    private KeyCode m_BendingLeft = KeyCode.A;

    private KeyCode m_BendingRight = KeyCode.E;

    private float m_PlayerSpeed;

    private Animator m_Animator;

    private void Start()
    {
        m_PlayerScript = GetComponent<Player>();
        m_PlayerSpeed = m_PlayerScript.speedMove;
        m_Animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Gizmos.DrawSphere(playerCamera.gameObject.transform.position, 0.5f);
        ChangePlayerSpeedOnBending();
        ChangePositionCameraOnBendingLeft();
        ChangePositionCameraOnBendingRight();
    }

    private void ChangePlayerSpeedOnBending()
    {
        if(Input.GetKeyDown(m_BendingLeft) || Input.GetKeyDown(m_BendingRight))
        {
            m_PlayerScript.speedMove = 0;
        }
        if (Input.GetKeyUp(m_BendingLeft) || Input.GetKeyUp(m_BendingRight))
        {
            m_PlayerScript.speedMove = m_PlayerSpeed;
        }
    }

    private void ChangePositionCameraOnBendingLeft()
    {
        
        if (Input.GetKeyDown(m_BendingLeft))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingLeftCrouching", true);
            else
                m_Animator.SetBool("IsBendingLeft", true);
        }
        if (Input.GetKeyUp(m_BendingLeft))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingLeftCrouching", false);
            else
                m_Animator.SetBool("IsBendingLeft", false);
        }
    }

    private void ChangePositionCameraOnBendingRight()
    {
        if (Input.GetKeyDown(m_BendingRight))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingRightCrouching", true);
            else
                m_Animator.SetBool("IsBendingRight", true);
        }
        if (Input.GetKeyUp(m_BendingRight))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingRightCrouching", false);
            else
                m_Animator.SetBool("IsBendingRight", false);
        }
    }
}
