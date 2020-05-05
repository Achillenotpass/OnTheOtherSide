using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject player;
    bool m_IsPaused = false;
    Player m_ScriptPlayer;
    FPSCamera m_ScriptCamera;
    Interaction m_ScriptInteraction;

    private void Start()
    {
        if(player != null)
        {
            m_ScriptPlayer = player.GetComponent<Player>();
            m_ScriptCamera = player.GetComponentInChildren<FPSCamera>();
            m_ScriptInteraction = player.GetComponentInChildren<Interaction>();
        }
    }
    void Update()
    {
        if (player != null) 
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
            m_ScriptInteraction.enabled = !m_ScriptInteraction.enabled;
            


        }
        else if (Input.GetKeyDown(KeyCode.Tab)&& m_IsPaused)
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

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        if(sceneName == "SecondFloor")
            Cursor.visible = false;
    }
}
