using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject player;
    bool m_IsPaused = false;
    Player m_ScriptPlayer;
    FPSCamera m_ScriptCamera;

    private void Start()
    {
        m_ScriptPlayer = player.GetComponent<Player>();
        m_ScriptCamera = player.GetComponentInChildren<FPSCamera>();
        Cursor.visible = false;
    }
    void Update()
    {
        PauseMenu();
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !m_IsPaused)
        {
            pause.SetActive(true);
            Cursor.visible = true;
            m_IsPaused = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            m_ScriptPlayer.enabled = !m_ScriptPlayer.enabled;
            m_ScriptCamera.enabled = !m_ScriptCamera.enabled;


        }
        else if (Input.GetKeyDown(KeyCode.Tab) && m_IsPaused)
        {
            StopMenu(pause);
        }
    }

    public void StopMenu(GameObject menu)
    {
        m_IsPaused = false;
        Cursor.visible = false;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        m_ScriptPlayer.enabled = !m_ScriptPlayer.enabled;
        m_ScriptCamera.enabled = !m_ScriptCamera.enabled;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
