using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    public string scene;
    public void Play()
    {
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        SceneManager.LoadScene(sceneName:"quitgame");
    }

}

