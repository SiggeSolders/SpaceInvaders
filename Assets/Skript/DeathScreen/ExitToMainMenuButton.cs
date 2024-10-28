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
        //nollst�ller endScore s� det blir nya scoret n�sta g�ng man f�rlorar
        SceneManager.LoadScene(sceneName: "Main Menu(Mira)");

        scoreKeeper.endScore = 0;
    }
}
