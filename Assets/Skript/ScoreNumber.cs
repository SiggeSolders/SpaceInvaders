using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreNumber : MonoBehaviour
{
    public ScoreManager sm;

    public TextMeshProUGUI scoretext;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score:" + sm.ScoreCount.ToString();
    }
}
