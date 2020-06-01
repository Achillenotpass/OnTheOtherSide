using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : Activable
{
    public string sceneToGoTo;

    public override void Interaction()
    {
        if (sceneToGoTo == "SecondFloor")
            Cursor.visible = false;
        if (sceneToGoTo == "2nd level")
            Cursor.visible = false;
        if (sceneToGoTo == "MaineMenu")
            Cursor.visible = true;
        if (sceneToGoTo == "Victory")
            Cursor.visible = true;
        SceneManager.LoadScene(sceneToGoTo);
    }
}
