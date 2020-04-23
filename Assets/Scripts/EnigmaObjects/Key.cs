using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Door doorToOpen;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == doorToOpen.gameObject)
        {
            doorToOpen.isLocked = false;
            Destroy(this.gameObject);
        }
    }
}
