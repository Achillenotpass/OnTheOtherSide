using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndVideo : MonoBehaviour
{

    public VideoPlayer video;
    public MenuScript menuScript;

    void Awake()
    {
        video.Play();
        video.loopPointReached += CheckOver;
    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        menuScript.ChangeScene("MainMenu");
    }
}