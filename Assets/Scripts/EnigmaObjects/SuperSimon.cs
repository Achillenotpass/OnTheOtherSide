using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSimon : Activable
{
    public List<Activable> objectsToActivate = new List<Activable>();

    public Activable[] superSimonArray;

    public List<Activable> superSimonList;

    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public override void Interaction()
    {
        if (superSimonList.Count == superSimonArray.Length)
        {
            for (int i = 0; i < superSimonArray.Length; i++)
            {
                if (superSimonArray[i] != superSimonList[i])
                {
                    Wrong();
                    return;
                }
            }
            foreach (Activable toActivate in objectsToActivate)
            {
                toActivate.Interaction();
            }
        }
        else
            Wrong();
    }

    void Wrong()
    {
        m_audioSource.Play();
        superSimonList.Clear();
    }
}
