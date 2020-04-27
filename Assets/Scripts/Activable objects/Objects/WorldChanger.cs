using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChanger : Activable
{
    public GameObject otherWorldSpawnPoint;

    public override void Interaction()
    {
        FindObjectOfType<Player>().transform.position = otherWorldSpawnPoint.transform.position;
    }
}
