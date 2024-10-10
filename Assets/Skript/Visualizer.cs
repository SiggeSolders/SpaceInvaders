using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour
{
    public Color visualizerColor = Color.gray;
    
    public VisualizerObjectSkript[] visualizerObjects;

    [Space(15)]
    public AudioClip audioClip;
    public bool loop = true;
    void Start()
    {
        visualizerObjects = GetComponentsInChildren<VisualizerObjectSkript>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < visualizerObjects.Length; i++)
        {
            visualizerObjects[i].GetComponent<Image>().color = visualizerColor;
        }
    }
}
