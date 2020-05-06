using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    public BoxCollider playerCollider;

    public Camera playerCamera;

    private Player m_PlayerScript;

    private CurveUtility m_CurveUtility;

    public AnimationCurve crouching;

    public AnimationCurve invCrouching;

    private KeyCode m_Crouching = KeyCode.C;

    private void Start()
    {
        m_PlayerScript = GetComponent<Player>();
        m_CurveUtility = GetComponent<CurveUtility>();
        m_CurveUtility.objectToAnimate = playerCamera.gameObject;
    }
    void Update()
    {
        ChangeColliderOnCrouching();
        ChangePositionCameraOnCrouching();
        ChangePlayerSpeedOnCrouching();
    }

    private void ChangePlayerSpeedOnCrouching()
    {
        if (Input.GetKeyDown(m_Crouching))
            m_PlayerScript.speedMove /= 2;
        if (Input.GetKeyUp(m_Crouching))
            m_PlayerScript.speedMove *= 2;

    }

    private void ChangeColliderOnCrouching()
    {
        if (Input.GetKeyDown(m_Crouching))
        {
            playerCollider.center = new Vector3(0, -0.439f, 0.190235f);
            playerCollider.size = new Vector3(0.5f, 0.878f, 0.7654327f);
        }
        if (Input.GetKeyUp(m_Crouching))
        {
            playerCollider.center = new Vector3(0, 0, 0.190235f);
            playerCollider.size = new Vector3(0.5f, 1.898272f, 0.7654327f);
        }
    }

    private void ChangePositionCameraOnCrouching()
    {
        if (Input.GetKeyDown(m_Crouching))
        {
            m_CurveUtility.axeY = crouching;
            m_CurveUtility.BeginMovement();
        }
        if(Input.GetKeyUp(m_Crouching))
        {
            m_CurveUtility.axeY = invCrouching;
            m_CurveUtility.BeginMovement();
        }
    }
}
