using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    AudioSource clickSound;

    void Awake()
    {
        clickSound = gameObject.GetComponent<AudioSource>();
    }

    // This method is now a coroutine.
    private IEnumerator LoadSceneAfterDelay(float delay, int sceneIndex)
    {
        // Play the click sound.
        clickSound.Play();
        
        // Wait for the specified delay.
        yield return new WaitForSeconds(delay);

        // Load the specified scene.
        SceneManager.LoadScene(sceneIndex);
    }

    public void Play()
    {
        // Call the coroutine with the desired delay and scene index.
        StartCoroutine(LoadSceneAfterDelay(1.5f, 2));
    }

    public void Options()
    {
        // Call the coroutine with the desired delay and scene index.
        StartCoroutine(LoadSceneAfterDelay(1.5f, 2));
    }

    public void Quit()
    {
        // Call the coroutine with the desired delay.
        StartCoroutine(QuitAfterDelay(1.5f));
    }

    // This method is a coroutine to quit the application after a delay.
    private IEnumerator QuitAfterDelay(float delay)
    {
        // Play the click sound.
        clickSound.Play();

        // Wait for the specified delay.
        yield return new WaitForSeconds(delay);

        // Quit the application.
        Application.Quit();
    }
}
