using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingLight : MonoBehaviour
{
    public Light[] lightActivated;
    public Light[] lightDesactivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (Light toDesactivate in lightDesactivated)
            {
                toDesactivate.gameObject.SetActive(false);
            }
            foreach (Light toActivate in lightActivated)
            {
                toActivate.gameObject.SetActive(true);
            }
        }
    }
}
