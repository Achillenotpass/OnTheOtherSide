using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MonoBehaviour
{
    public BoxCollider playerCollider;

    public Camera playerCamera;

    private Player m_PlayerScript;

    private Animator m_Animator;

    private void Start()
    {
        m_PlayerScript = GetComponent<Player>();
        m_Animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        ChangeColliderOnCrouching();
        ChangePositionCameraOnCrouching();
        ChangePlayerSpeedOnCrouching();
    }

    private void ChangePlayerSpeedOnCrouching()
    {
        if (Input.GetButtonDown("Crouching"))
            m_PlayerScript.speed /= 3;
        if (Input.GetButtonUp("Crouching"))
            m_PlayerScript.speed *= 3;

    }

    private void ChangeColliderOnCrouching()
    {
        if (Input.GetButtonDown("Crouching"))
        {
            playerCollider.center = new Vector3(0, -0.439f, 0.190235f);
            playerCollider.size = new Vector3(0.65f, 0.878f, 0.65f);
        }
        if (Input.GetButtonUp("Crouching"))
        {
            playerCollider.center = new Vector3(0, 0, 0.190235f);
            playerCollider.size = new Vector3(0.65f, 1.898272f, 0.65f);
        }
    }

    private void ChangePositionCameraOnCrouching()
    {
        if (Input.GetButtonDown("Crouching"))
        {
            m_Animator.SetBool("IsCrouching", true);
        }
        if(Input.GetButtonUp("Crouching"))
        {
            m_Animator.SetBool("IsCrouching", false);
        }
    }
}
