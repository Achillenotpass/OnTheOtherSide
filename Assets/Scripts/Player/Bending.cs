using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Bending : MonoBehaviour
{
    public Camera playerCamera;

    private CurveUtility m_CurveUtility;

    private Player m_PlayerScript;

    public AnimationCurve bendingLeftX;
    public AnimationCurve bendingLeftY;

    public AnimationCurve invBendingLeftX;
    public AnimationCurve invBendingLeftY;

    public AnimationCurve bendingRightX;
    public AnimationCurve bendingRightY;

    public AnimationCurve invBendingRightX;
    public AnimationCurve invBendingRightY;

    private KeyCode m_BendingLeft = KeyCode.A;

    private KeyCode m_BendingRight = KeyCode.E;

    private float m_PlayerSpeed;

    private Animator m_Animator;

    private void Start()
    {
        m_PlayerScript = GetComponent<Player>();
        m_CurveUtility = GetComponent<CurveUtility>();
        m_CurveUtility.objectToAnimate = playerCamera.gameObject;
        m_PlayerSpeed = m_PlayerScript.speedMove;
        m_Animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
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
            if(m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingLeftCrouching", true);
            else
                m_Animator.SetBool("IsBendingLeft", true);
            //m_CurveUtility.axeY = bendingLeftY;
            //m_CurveUtility.axeX = bendingLeftX;
            //m_CurveUtility.BeginMovement();
        }
        if(Input.GetKeyUp(m_BendingLeft))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingLeftCrouching", false);
            else
                m_Animator.SetBool("IsBendingLeft", false);
            //m_CurveUtility.axeY = invBendingLeftY;
            //m_CurveUtility.axeX = invBendingLeftX;
            //m_CurveUtility.BeginMovement();
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
            //m_CurveUtility.axeY = bendingRightY;
            //m_CurveUtility.axeX = bendingRightX;
            //m_CurveUtility.BeginMovement();
        }
        if (Input.GetKeyUp(m_BendingRight))
        {
            if (m_Animator.GetBool("IsCrouching"))
                m_Animator.SetBool("IsBendingRightCrouching", false);
            else
                m_Animator.SetBool("IsBendingRight", false);
            //m_CurveUtility.axeY = invBendingRightY;
            //m_CurveUtility.axeX = invBendingRightX;
            //m_CurveUtility.BeginMovement();
        }
    }
}
