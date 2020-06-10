using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScreen : MonoBehaviour
{
    public GameObject[] toActivate;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(this.gameObject);

            for (int i = 0; i < toActivate.Length; i++)
            {
                toActivate[i].GetComponent<Activable>().Interaction();
            }
        }
    }
}
