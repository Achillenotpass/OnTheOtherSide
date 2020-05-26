using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    public GameObject[] toActivate;
    public Player player;
    

    private void Update()
    {
        transform.LookAt(player.transform);
        transform.Rotate(0.0f, -90.0f,  45.0f - transform.rotation.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].GetComponent<Activable>().Interaction();
        }

        if (collision.gameObject.tag == "Movable")
        {
            Destroy(this.gameObject);
        }
    }
}
