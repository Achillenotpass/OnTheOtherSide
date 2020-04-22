using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    private BoxCollider m_PlayerCollider;

    private Camera m_PlayerCamera;

    private Player m_PlayerScript;

    private CurveUtility m_CurveUtility;

    public AnimationCurve crouching;

    public AnimationCurve invCrouching;

    private void Start()
    {
        m_PlayerCollider = GetComponentInChildren<BoxCollider>();
        m_PlayerCamera = GetComponentInChildren<Camera>();
        m_PlayerScript = GetComponent<Player>();
        m_CurveUtility = GetComponent<CurveUtility>();
        m_CurveUtility.objectToAnimate = m_PlayerCamera.gameObject;
    }
    void Update()
    {
        ChangeColliderOnCrouching();
        ChangePositionCameraOnCrouching();
        ChangePlayerSpeedOnCrouching();
    }

    private void ChangePlayerSpeedOnCrouching()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            m_PlayerScript.speedMove /= 2;
        if (Input.GetKeyUp(KeyCode.LeftAlt))
            m_PlayerScript.speedMove *= 2;

    }

    private void ChangeColliderOnCrouching()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_PlayerCollider.center = new Vector3(0, -0.25f, 0);
            m_PlayerCollider.size = new Vector3(1, 0.5f, 1);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            m_PlayerCollider.center = new Vector3(0, 0, 0);
            m_PlayerCollider.size = new Vector3(1, 1.756f, 1);
        }
    }

    private void ChangePositionCameraOnCrouching()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_CurveUtility.axeY = crouching;
            m_CurveUtility.BeginMovement();
        }
        if(Input.GetKeyUp(KeyCode.C))
        {
            m_CurveUtility.axeY = invCrouching;
            m_CurveUtility.BeginMovement();
        }
    }
}
