using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour
{
    public float updateSenistivity = 0.5f;

    public Sprite visualizerSprite;

    [Space(15)]
    public AudioClip audioClip;
    public bool loop = true;
    [Space(15), Range(64, 8192)]
    public int visualzierSimples = 64;

    public VisualizerObjectSkript[] visualizerObjects;
    public Image[] visualizerImage;
    AudioSource m_audioSource;

    void Start()
    {
        visualizerObjects = GetComponentsInChildren<VisualizerObjectSkript>();
        visualizerImage = GetComponentsInChildren<Image>();

        if (!audioClip)
        {
            return;
        }
        m_audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();
        m_audioSource.loop = loop;
        m_audioSource.clip = audioClip;
        m_audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrumData = new float[64];

        m_audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

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
