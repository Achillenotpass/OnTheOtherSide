using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeTrigger : MonoBehaviour
{
    public List<Activable> objectsToActivate = new List<Activable>();

    public TriggerStates currentTriggerStates = TriggerStates.Normal;

    public float timerForReactivation = 1;

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            foreach (Activable toActivate in objectsToActivate)
            {
                toActivate.Interaction();
            }
            switch (currentTriggerStates)
            {
                case TriggerStates.OneTime:
                    Invoke("OneTime", 0.01f);
                    break;
                case TriggerStates.MultipleTime:
                    Invoke("MultipleTime", 0.01f);
                    break;
            }
            
            
        }
    }

    private void OneTime()
    {
        Destroy(gameObject);
    }

    private void MultipleTime()
    {
        Invoke("ReactiveTrigger", timerForReactivation);
        gameObject.SetActive(false);
    }

    private void ReactiveTrigger()
    {
        gameObject.SetActive(true);
    }
}


public enum TriggerStates
{
    Normal,
    OneTime,
    MultipleTime,
}
