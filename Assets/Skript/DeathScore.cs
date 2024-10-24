using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor.UI;

public class DeathScore : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    GameObject scoreObject;

    GameManager score;

    int deathScore;

    private void Awake()
    {
        scoreObject = GameObject.FindWithTag("GameManager");

        textMeshPro = GetComponent<TextMeshProUGUI>();

        score = scoreObject.GetComponent<GameManager>();

        deathScore = score.playerScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = deathScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
