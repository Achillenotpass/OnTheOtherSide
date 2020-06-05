using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : Activable
{
    public string sceneToGoTo;

    public MenuScript menuScript;

    public override void Interaction()
    {
        menuScript.ChangeScene(sceneToGoTo);
        /*if (sceneToGoTo == "SecondFloor")
            Cursor.visible = false;
        if (sceneToGoTo == "2nd level")
            Cursor.visible = false;
        if (sceneToGoTo == "MainMenu")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (sceneToGoTo == "Victory")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        SceneManager.LoadScene(sceneToGoTo);*/
    }
}
