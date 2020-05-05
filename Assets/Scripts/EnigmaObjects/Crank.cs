using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : Activable
{
    public List<Activable> objectsToActivate = new List<Activable>();

    public float maxGauge = 5;

    public float currentGauge = 0;

    bool m_IsCranking = false;

    public GameObject player;

    private Player m_ScriptPlayer;

    private FPSCamera m_ScriptCamera;

    private Camera m_Camera;

    public GameObject handle;

    private void Start()
    {
        m_ScriptPlayer = player.GetComponent<Player>();
        m_ScriptCamera = player.GetComponentInChildren<FPSCamera>();
        m_Camera = player.GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if(m_IsCranking)
        {
            Cranked();
        }
    }

    public override void Interaction()
    {
        m_ScriptPlayer.enabled = !enabled;
        //m_ScriptCamera.enabled = !enabled;
        switch(m_Camera.fieldOfView)
        {
            case 60:
                m_Camera.fieldOfView = 55;
                break;
            case 55:
                m_Camera.fieldOfView = 60;
                break;
        }
        handle.tag = "Movable";
        m_IsCranking = true;
    }

    void Cranked()
    {


        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            if (currentGauge >= maxGauge)
            {
                foreach (Activable toActivate in objectsToActivate)
                {
                    toActivate.Interaction();
                }
                gameObject.tag = "Untagged";
                Debug.Log("aaa");
            }
            else
            {
                currentGauge += 1 * Time.deltaTime;
                transform.Rotate(0, 0, 1);
            }
        }*/
    }
}