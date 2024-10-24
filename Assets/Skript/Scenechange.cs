using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    public string scene;
    private AudioSource buttonSound;
    public void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }
    private IEnumerator QuitGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName: "quitgame");
    }
    private IEnumerator LoadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
    public void Play()
    {
        StartCoroutine(LoadScene(0.3f));
        buttonSound.Play();
    }
    public void Quit()
    {
        SceneManager.LoadScene(sceneName:"quitgame");
        buttonSound.Play();
        StartCoroutine(QuitGame(0.3f));
    }

}

