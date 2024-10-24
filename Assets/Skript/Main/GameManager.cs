using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public ScreenShake _screenShake;
    private Player player;
    private Invaders invaders;
    private MysteryShip mysteryShip;
    private Bunker[] bunkers;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI multiplierText;
    public GameObject multiplier; 

    //Används ej just nu, men ni kan använda de senare
    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    public int playerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        multiplier.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        invaders = FindObjectOfType<Invaders>();
        mysteryShip = FindObjectOfType<MysteryShip>();
        bunkers = FindObjectsOfType<Bunker>();


        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.GetKeyDown(KeyCode.Return))
        {
            NewGame();
        }
        SetMultiplier();
    }

    private void NewGame()
    {

        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        invaders.ResetInvaders();
        invaders.gameObject.SetActive(true);

        for (int i = 0; i < bunkers.Length; i++)
        {
            bunkers[i].ResetBunker();
        }

        Respawn();
    }

    private void Respawn()
    {
        Vector3 position = player.transform.position;
        position.x = 0f;
        player.transform.position = position;
        player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        invaders.gameObject.SetActive(false);
    }

    private void SetScore(int playerScore)
    {
        score = playerScore;
        scoretext.text = "Score: " + playerScore;
        Debug.Log("score: " + playerScore);
    }
    public void SetMultiplier()
    {
        multiplierText.text = player.multiplier + "X";
        if (player.multiplier > 1)
        {
            multiplier.SetActive(true);
        }
        else
        {
            multiplier.SetActive(false);
        }
    }


    private void SetLives(int lives)
    {
       
    }

    public void OnPlayerKilled(Player player)
    {

        player.gameObject.SetActive(false);

        SceneManager.LoadScene(sceneName: "DeathScreen");
    }

    public void OnInvaderKilled(Invader invader)
    {
        invader.gameObject.SetActive(false);
       
        if(invader.invaderType == 1)
        {
            SetScore(score + (100 * player.multiplier));
        }

        if (invader.invaderType == 2)
        {
            SetScore(score + (150 * player.multiplier));
        }

        if (invader.invaderType == 3)
        {
            SetScore(score + (300 * player.multiplier));
        }
        if (invaders.GetInvaderCount() == 0)
        {
            NewRound();
        }
    }

    public void OnMysteryShipKilled(MysteryShip mysteryShip)
    {
        mysteryShip.gameObject.SetActive(false);
        SetScore(score + (500 * player.multiplier));
    }

    public void OnBoundaryReached()
    {
        if (invaders.gameObject.activeSelf)
        {
            invaders.gameObject.SetActive(false);
            OnPlayerKilled(player);
        }
    }

    public void StartShaking()
    {
        StartCoroutine(_screenShake.Shaking());
    }

}
