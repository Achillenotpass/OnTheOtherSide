using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendingCollider : MonoBehaviour
{
    private Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            Debug.Log("aaa");
            if (m_Animator.GetBool("IsCrouching"))
            {
                m_Animator.SetBool("IsBendingLeftCrouching", false);
                m_Animator.SetBool("IsBendingRightCrouching", false);
            }
            else
            {
                m_Animator.SetBool("IsBendingLeft", false);
                m_Animator.SetBool("IsBendingRight", false);
            }
        }
    }
}
