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

        //när scenen byts till SampleScene ska detta skript få tag på spelets gamemanager som ligger i SampleScene
        if(activeScene.name == "SampleScene" && gameManager == null)
        {
            gameManager = GameObject.Find("GameManager");

            scoreTarget = gameManager.GetComponent<GameManager>();
        }

        //endScore är det score som visas på game over screenen, uppdateras när skriptet får tag på gamemanagern
        if(gameManager != null)
        {
            endScore = scoreTarget.score;
        }
    }
}
