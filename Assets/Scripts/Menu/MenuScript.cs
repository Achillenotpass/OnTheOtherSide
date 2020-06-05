using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject player;
    bool m_IsPaused = false;
    Player m_ScriptPlayer;
    FPSCamera m_ScriptCamera;
    Interaction m_ScriptInteraction;

    public GameObject loadingScreen;
    public Slider loading;
    public List<Image> comments;

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
        m_ScriptInteraction.enabled = !m_ScriptInteraction.enabled;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        
        Time.timeScale = 1;
        StartCoroutine(LoadAsynchronously(sceneName));
        if (sceneName == "SecondFloor")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (sceneName == "2nd level")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (sceneName == "MainMenu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (sceneName == "Victory")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        loadingScreen.SetActive(true);

        LoadingScreenComments();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        //Debug.Log("aaa");

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loading.value = progress;

            //Debug.Log(operation.progress);

            yield return null;
        }
    }

    public void LoadingScreenComments()
    {
        int r = Random.Range(0, comments.Count - 1);

        for(int i = 0; i < comments.Count; i++)
        {
            if (i == r)
                comments[i].gameObject.SetActive(true);
            else
                comments[i].gameObject.SetActive(false);
        }
    }
}
