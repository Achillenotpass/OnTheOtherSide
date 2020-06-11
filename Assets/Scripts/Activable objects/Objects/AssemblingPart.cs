using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblingPart : MonoBehaviour
{
    public List<Activable> objectsToActivate = new List<Activable>();
    public List<Activable> objectsToActivate1 = new List<Activable>();
    public List<Activable> objectsToActivate2 = new List<Activable>();
    public List<Activable> objectsToActivate3 = new List<Activable>();

    public List<string> nameOfPart = new List<string>();

    public int totalNumberOfParts = 1;

    public int currentNumberOfParts = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Movable")
        {
            for(int i = 0; i < nameOfPart.Count; i++)
            {
                if(collision.gameObject.name == nameOfPart[i])
                {
                    currentNumberOfParts += 1;

                    switch (currentNumberOfParts)
                    {
                        case 1:
                            foreach (Activable toActivate in objectsToActivate1)
                            {
                                toActivate.Interaction();
                            }
                            break;
                        case 2:
                            foreach (Activable toActivate in objectsToActivate2)
                            {
                                toActivate.Interaction();
                            }
                            break;
                        case 3:
                            foreach (Activable toActivate in objectsToActivate3)
                            {
                                toActivate.Interaction();
                            }
                            break;

                    }

                    for (int z = 0; z < transform.childCount; z++)
                    {
                        if(transform.GetChild(z).name == collision.gameObject.name)
                        {
                            transform.GetChild(z).gameObject.SetActive(true);
                        }
                    }
                    if (currentNumberOfParts >= totalNumberOfParts)
                    {
                        foreach (Activable toActivate in objectsToActivate)
                        {
                            toActivate.Interaction();
                        }
                    }
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }
}
