using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChanger : Activable
{
    public GameObject otherWorldSpawnPoint;

    public Camera playerCamera;

    private bool m_IsChangingCamera;
    private bool m_IsIncreasing = true;

    public float increaseIncrementalValue;
    public float decreaseIncrementalValue;

    private float m_StartFOV;
    public float minFOV;
    public float maxFOV;

    //SOUNDS
    private AudioSource m_AudioSource;


    private void Start()
    {
        m_StartFOV = playerCamera.fieldOfView;
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (m_IsChangingCamera)
        {
            if (m_IsIncreasing)
            {
                if (playerCamera.fieldOfView <= maxFOV)
                {
                    playerCamera.fieldOfView = playerCamera.fieldOfView + increaseIncrementalValue * Time.deltaTime * 60;
                }
                else
                {
                    m_IsIncreasing = false;
                }
            }
            else if (playerCamera.fieldOfView >= minFOV)
            {
                playerCamera.fieldOfView = playerCamera.fieldOfView - decreaseIncrementalValue * Time.deltaTime * 60;
            }
            else
            {
                m_IsIncreasing = true;
                m_IsChangingCamera = false;
                WorldChange();
                playerCamera.fieldOfView = m_StartFOV;

                playerCamera.gameObject.GetComponent<FPSCamera>().enabled = true;
                playerCamera.gameObject.GetComponent<Interaction>().enabled = true;
                playerCamera.gameObject.GetComponentInParent<Player>().enabled = true;
                playerCamera.gameObject.GetComponentInParent<Crouching>().enabled = true;
            }
        }
    }


    public override void Interaction()
    {
        m_IsIncreasing = true;
        m_IsChangingCamera = true;

        playerCamera.gameObject.GetComponent<FPSCamera>().enabled = false;
        playerCamera.gameObject.GetComponent<Interaction>().enabled = false;
        playerCamera.gameObject.GetComponentInParent<Player>().enabled = false;
        playerCamera.gameObject.GetComponentInParent<Crouching>().enabled = false;

        m_AudioSource.pitch = Random.Range(0.85f, 1.15f);
        m_AudioSource.Play();
    }

    private void WorldChange()
    {
        FindObjectOfType<Player>().transform.position = otherWorldSpawnPoint.transform.position;
    }
}
