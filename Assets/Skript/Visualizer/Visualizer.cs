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
        //Hämtar de actuella komponenterna
        audioSource = audioClipSource.GetComponent<AudioSource>();

        visualizerObjects = GetComponentsInChildren<VisualizerObjectSkript>();
        visualizerImage = GetComponentsInChildren<Image>();

        //Om det inte finns något ljud körs inte skriptet
        if (!audioSource)
        {
            return;
        }
    }
    void Update()
    {
        //Hämtar ljudets "spectrum data" för att dela upp det i sina beståndsdelar
        float[] spectrumData = new float[64];

        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        //ändrar storlekan på objecten under visualizern så att de matchar specrumdatan
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
