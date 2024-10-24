using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor.UI;

public class DeathScore : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;

    GameObject scoreObject;

    ScoreKeeper scoreKeeper;

    int deathScore;

    private void Awake()
    {
        scoreObject = GameObject.Find("ScoreKeeper");

        textMeshPro = GetComponent<TextMeshProUGUI>();

        scoreKeeper = scoreObject.GetComponent<ScoreKeeper>();

        deathScore = scoreKeeper.endScore;
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
