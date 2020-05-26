using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomWall : Activable
{
    private bool m_IsDying = false;

    public override void Interaction()
    {
        m_IsDying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsDying)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.4f * Time.deltaTime, transform.localScale.z);
            if (transform.localScale.y <= 0.2f)
            {
                Destroy(gameObject);
            }
        }
    }
}
