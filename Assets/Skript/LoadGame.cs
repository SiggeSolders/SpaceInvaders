using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(sceneName: "Main Menu(Mira)");
    }
}
