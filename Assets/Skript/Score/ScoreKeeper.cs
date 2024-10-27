using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;

    GameManager scoreTarget;

    public int endScore;

    public UnityEngine.SceneManagement.Scene activeScene;

    private void Awake()
    {
        Object.DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeScene = SceneManager.GetActiveScene();

        //n�r scenen byts till SampleScene ska detta skript f� tag p� spelets gamemanager som ligger i SampleScene
        if(activeScene.name == "SampleScene" && gameManager == null)
        {
            gameManager = GameObject.Find("GameManager");

            scoreTarget = gameManager.GetComponent<GameManager>();
        }

        //endScore �r det score som visas p� game over screenen, uppdateras n�r skriptet f�r tag p� gamemanagern
        if(gameManager != null)
        {
            endScore = scoreTarget.score;
        }
    }
}
