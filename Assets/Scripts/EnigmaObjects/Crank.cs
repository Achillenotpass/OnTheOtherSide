using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crank : Activable
{
    public List<Activable> objectsToActivate = new List<Activable>();

    public AnimationCurve positionArrow;

    public GameObject arrow;

    public float maxGauge = 5;

    public float currentGauge = 0;

    bool m_IsCranking = true;

    public GameObject player;

    private Player m_ScriptPlayer;

    private Camera m_Camera;

    public GameObject handle;

    private void Start()
    {
        m_ScriptPlayer = player.GetComponent<Player>();
        m_Camera = player.GetComponentInChildren<Camera>();
        Keyframe[] keyFrame = positionArrow.keys;
        keyFrame[0].time = 0;
        keyFrame[0].value = -54;
        keyFrame[1].time = maxGauge;
        keyFrame[1].value = 54;
        positionArrow.keys = keyFrame;
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
        /*switch(m_ScriptPlayer.enabled)
        {
            case true:
                m_ScriptPlayer.enabled = false;
                break;
            case false:
                m_ScriptPlayer.enabled = true;
                break;
        }
        switch(m_IsCranking)
        {
            case true:
                m_IsCranking = false;
                break;
            case false:
                m_IsCranking = true;
                break;
        }*/
    }

    void Cranked()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hitInfo, 10))
            {
                if (hitInfo.transform.gameObject == gameObject)
                {
                    if (currentGauge >= maxGauge)
                    {
                        foreach (Activable toActivate in objectsToActivate)
                        {
                            toActivate.Interaction();
                        }
                        gameObject.tag = "Untagged";
                        m_ScriptPlayer.enabled = true;
                        m_IsCranking = false;
                        Debug.Log("aaa");
                    }
                    else
                    {
                        currentGauge += 1 * Time.deltaTime;
                        handle.transform.Rotate(1, 0, 0);
                        arrow.transform.localRotation = Quaternion.Euler(0 + positionArrow.Evaluate(currentGauge), 0, 0);
                    }
                }
            }
            
        }
    }
}