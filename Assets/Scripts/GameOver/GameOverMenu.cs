using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    AudioSource buttonSound;
    
    void Awake()
    {
        buttonSound = gameObject.GetComponent<AudioSource>();
    }
    public void Restart()
    {
        StartCoroutine(LoadSceneAfterDelay(1.5f , SceneManager.GetActiveScene().buildIndex));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        StartCoroutine(LoadSceneAfterDelay(1.5f , 0)); // Assuming your main menu is in build index 0
    }

    public void Space()
    {
        StartCoroutine(LoadSceneAfterDelay(1.5f , 1)); // Change to the appropriate build index for the "Space" scene
    }

    private IEnumerator LoadSceneAfterDelay(float delay, int sceneIndex)
    {
        // Play the click sound.
        buttonSound.Play();
        
        // Wait for the specified delay.
        yield return new WaitForSeconds(delay);

        // Load the specified scene.
        SceneManager.LoadScene(sceneIndex);
    }
}
//Vanakam