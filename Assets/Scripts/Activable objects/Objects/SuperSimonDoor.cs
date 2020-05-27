using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSimonDoor : Activable
{
    public List<Activable> toActivateWhenBroken;

    public int numberOfHitToDestroy = 3;
    private int m_CurrentNumberOfHit = 0;


    public override void Interaction()
    {
        Hit();
    }

    void Hit()
    {
        m_CurrentNumberOfHit = m_CurrentNumberOfHit + 1;
        if (m_CurrentNumberOfHit == numberOfHitToDestroy)
        {
            Destroyed();
        }
    }

    void Destroyed()
    {
        foreach (Activable toActivate in toActivateWhenBroken)
        {
            toActivate.Interaction();
        }
    }
}
