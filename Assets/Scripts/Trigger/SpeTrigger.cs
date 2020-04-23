using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeTrigger : MonoBehaviour
{
    public TriggerStates currentTriggerStates = TriggerStates.Normal;

    public float timerForReactivation = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("OneTime", 0.01f);
            Invoke("MultipleTime", 0.01f);
        }
    }

    private void OneTime()
    {
        if(currentTriggerStates == TriggerStates.OneTime)
        {
            Destroy(gameObject);
        }
    }

    private void MultipleTime()
    {
        if (currentTriggerStates == TriggerStates.MultipleTime)
        {
            Invoke("ReactiveTrigger", timerForReactivation);
            gameObject.SetActive(false);
        }
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
