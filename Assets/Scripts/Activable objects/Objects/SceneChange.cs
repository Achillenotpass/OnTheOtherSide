using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : Activable
{
    public string sceneToGoTo;

    public override void Interaction()
    {
        SceneManager.LoadScene(sceneToGoTo);
    }
}
