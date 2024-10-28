using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        //nollställer endScore så det blir nya scoret nästa gång man förlorar
        SceneManager.LoadScene(sceneName: "Main Menu(Mira)");

        scoreKeeper.endScore = 0;
    }
}
