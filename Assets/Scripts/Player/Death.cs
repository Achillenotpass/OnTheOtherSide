using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject respawnPoint;

    private bool m_IsDying = false;
    public float deathTime;

    //To disable
    public GameObject canvas;
    public GameObject deathCanvas;

    private Player m_Player;
    private Bending m_Bending;
    private Crouching m_Crouching;
    private FPSCamera m_FPSCamera;
    private Interaction m_Interaction;


    private void Update()
    {
        
    }

    public void Die()
    {
        transform.position = respawnPoint.transform.position;

        m_Player = FindObjectOfType<Player>();
        m_Bending = FindObjectOfType<Bending>();
        m_Crouching = FindObjectOfType<Crouching>();
        m_FPSCamera = FindObjectOfType<FPSCamera>();
        m_Interaction = FindObjectOfType<Interaction>();

        canvas.SetActive(false);
        deathCanvas.SetActive(true);
        m_Player.enabled = false;
        m_Bending.enabled = false;
        m_Crouching.enabled = false;
        m_FPSCamera.enabled = false;
        m_Interaction.enabled = false;

        Invoke("Revive", deathTime);
    }

    public void Revive()
    {
        canvas.SetActive(true);
        deathCanvas.SetActive(false);
        m_Player.enabled = true;
        m_Bending.enabled = true;
        m_Crouching.enabled = true;
        m_FPSCamera.enabled = true;
        m_Interaction.enabled = true;
    }
}
