using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour
{
    public float updateSenistivity = 0.5f;

    public Sprite visualizerSprite;

    [Space(15)]
    public GameObject audioClipSource;
    private AudioSource audioSource;
    public bool loop = true;
    [Space(15), Range(64, 8192)]
    public int visualzierSimples = 64;

    public VisualizerObjectSkript[] visualizerObjects;
    public Image[] visualizerImage;

    void Start()
    {
        audioSource = audioClipSource.GetComponent<AudioSource>();

        visualizerObjects = GetComponentsInChildren<VisualizerObjectSkript>();
        visualizerImage = GetComponentsInChildren<Image>();

        if (!audioSource)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrumData = new float[64];

        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        for (int i = 0; i < visualizerObjects.Length; i++)
        {
            float newSize = visualizerObjects[i].GetComponent<Image>().fillAmount;
            newSize =  Mathf.Lerp(newSize, spectrumData[i] * 2, updateSenistivity);
            visualizerObjects[i].GetComponent<Image>().fillAmount = newSize;

            Image image = visualizerObjects[i].GetComponent<Image>();
            visualizerObjects[i].GetComponent<Image>().sprite = visualizerSprite;
        }
    }
}
