using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject player;
    bool isPaused = false;
    Player scriptPlayer;
    FPSCamera scriptCamera;

    private void Start()
    {
        scriptPlayer = player.GetComponent<Player>();
        scriptCamera = player.GetComponentInChildren<FPSCamera>();
        Cursor.visible = false;
    }
    void Update()
    {
        PauseMenu();
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isPaused)
        {
            pause.SetActive(true);
            Cursor.visible = true;
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            scriptPlayer.enabled = !scriptPlayer.enabled;
            scriptCamera.enabled = !scriptCamera.enabled;


        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isPaused)
        {
            StopMenu(pause);
        }
    }

    public void StopMenu(GameObject menu)
    {
        isPaused = false;
        Cursor.visible = false;
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        scriptPlayer.enabled = !scriptPlayer.enabled;
        scriptCamera.enabled = !scriptCamera.enabled;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
