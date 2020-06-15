using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Bending : MonoBehaviour
{
    public Camera playerCamera;

    private Player m_PlayerScript;

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
        if(Input.GetButtonDown("BendingLeft") || Input.GetButtonDown("BendingRight"))
        {
            m_PlayerScript.speedMove = 0;
        }
        if (Input.GetButtonUp("BendingLeft") || Input.GetButtonUp("BendingRight"))
        {
            m_PlayerScript.speedMove = m_PlayerSpeed;
        }
    }

    private void ChangePositionCameraOnBendingLeft()
    {
        
        if (Input.GetButtonDown("BendingLeft"))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingLeftCrouching", true);
            else
                m_Animator.SetBool("IsBendingLeft", true);
        }
        if (Input.GetButtonUp("BendingLeft"))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingLeftCrouching", false);
            else
                m_Animator.SetBool("IsBendingLeft", false);
        }
    }

    private void ChangePositionCameraOnBendingRight()
    {
        if (Input.GetButtonDown("BendingRight"))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingRightCrouching", true);
            else
                m_Animator.SetBool("IsBendingRight", true);
        }
        if (Input.GetButtonUp("BendingRight"))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingRightCrouching", false);
            else
                m_Animator.SetBool("IsBendingRight", false);
        }
    }
}
