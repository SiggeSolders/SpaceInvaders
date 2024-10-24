using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class ExitToMainMenuButton : MonoBehaviour
{
    GameObject gameObject;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        gameObject = GameObject.Find("ScoreKeeper");

        scoreKeeper = gameObject.GetComponent<ScoreKeeper>();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(sceneName: "Main Menu(Mira)");

        scoreKeeper.endScore = 0;
    }
}
