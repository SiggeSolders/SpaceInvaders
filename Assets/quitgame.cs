using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    //Denna kod gör så att man går ut från player mode när man trycker på quit knappen
}
