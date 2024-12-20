using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public GameObject ringObject;

    public static GameManager Instance { get; private set; }

    public ScreenShake _screenShake;
    private Player player;
    private Invaders invaders;
    private MysteryShip mysteryShip;
    private Bunker[] bunkers;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI multiplierText;
    public GameObject multiplier; 

    //Anv�nds ej just nu, men ni kan anv�nda de senare
    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    public int playerScore;

    public GameObject PlayerHit;
    public GameObject InvaderHit;

    private AudioSource playerDeath;
    private AudioSource invaderDeath;

    private void Awake()
    {
        ringObject.SetActive(false);

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
        playerDeath = PlayerHit.GetComponent<AudioSource>();
        invaderDeath = InvaderHit.GetComponent<AudioSource>();

        StartCoroutine(StartRingAnimation(1.0f));

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
        StartRingAnimation(0.5f);
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
        scoretext.text = "Score:           " + playerScore;
        Debug.Log("score: " + playerScore);
    }
    public void SetMultiplier()
    {
        //S�tter multipliern utifr�n player skriptet och visar den om den �r mer �n 1
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
    //v�ntar med att byta scen s� man kan h�ra death-sound
    private IEnumerator DeathSwitch(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName: "DeathScreen");
    }
    private void SetLives(int lives)
    {
       
    }

    public void OnPlayerKilled(Player player)
    {

        player.gameObject.SetActive(false);
        playerDeath.Play();

        StartCoroutine(DeathSwitch(1.0f));
    }
    //�kar score n�r en invader blir tr�ffad utifr�n vilken invader det �r och vad multiplierns v�rde ligger p�
    public void OnInvaderKilled(Invader invader)
    {
        invader.gameObject.SetActive(false);
        invaderDeath.Play();
       
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
    //Startar screenshake
    public void StartShaking()
    {
        StartCoroutine(_screenShake.Shaking());
    }

    public IEnumerator StartRingAnimation(float delay)
    {
        Debug.Log("Animation");
        yield return new WaitForSeconds(delay);
        ringObject.SetActive(true);
    }

}
