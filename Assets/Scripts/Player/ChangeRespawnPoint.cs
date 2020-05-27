using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRespawnPoint : MonoBehaviour
{
    public Player player;
    public GameObject newRespawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Death>().respawnPoint = newRespawnpoint;
        }
    }
}
