using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSimonInterruptor : Activable
{
    public SuperSimon superSimon;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    public override void Interaction()
    {
        superSimon.superSimonList.Add(this);
        superSimon.Interaction();
        m_Animator.SetTrigger("Activated");
    }
}
