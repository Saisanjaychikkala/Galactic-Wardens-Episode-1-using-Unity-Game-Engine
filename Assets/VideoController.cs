using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;
    public float timeBeforeSceneTransition = 1f;

    private float elapsedTime = 0f;

    void Start()
    {
        videoPlayer.Play();
    }

    void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeBeforeSceneTransition)
            {
                LoadNextScene();
            }
        }
    }
    //gg
    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
