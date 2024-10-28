using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    GameObject gameObject;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        gameObject = GameObject.Find("ScoreKeeper");

        scoreKeeper = gameObject.GetComponent<ScoreKeeper>();
    }

    public void Restart()
    {
        //nollställer endScore så det blir nya scoret nästa gång man förlorar
        SceneManager.LoadScene(sceneName: "SampleScene");

        scoreKeeper.endScore = 0;
    }
}
