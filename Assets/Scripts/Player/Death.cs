using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject respawnPoint;

    private bool m_IsDying = false;

    private void Update()
    {
        
    }

    public void Die()
    {
        m_IsDying = true;
        if (m_IsDying)
        {
            transform.position = respawnPoint.transform.position;
            m_IsDying = false;
        }
    }
}
