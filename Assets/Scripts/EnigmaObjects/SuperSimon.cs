using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSimon : Activable
{
    public List<Activable> objectsToActivateWhenRight = new List<Activable>();
    public List<Activable> objectsToActivateWhenWrong = new List<Activable>();

    public Activable[] superSimonArray;

    public List<Activable> superSimonList;

    public int currentListIndex = 0;

    private bool m_FinishedSuperSimon = false;

    






    public override void Interaction()
    {

        if (!m_FinishedSuperSimon)
        {
            if (superSimonList[currentListIndex] == superSimonArray[currentListIndex])
            {
                if ((currentListIndex + 1) == superSimonArray.Length)
                {
                    Right();
                }
                else
                {
                    currentListIndex = currentListIndex + 1;
                }
            }
            else
            {
                Wrong();
            }
        }
    }


    void Right()
    {
        foreach (Activable toActivate in objectsToActivateWhenRight)
        {
            toActivate.Interaction();
        }
    }

    void Wrong()
    {
        foreach (Activable toActivate in objectsToActivateWhenWrong)
        {
            toActivate.Interaction();
        }
        superSimonList.Clear();
        currentListIndex = 0;
    }
}
