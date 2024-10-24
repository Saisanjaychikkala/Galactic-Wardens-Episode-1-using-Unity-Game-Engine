using UnityEngine;
using UnityEngine.Video;

public class PlayAndLoopVideo : MonoBehaviour
{
    /*public VideoPlayer videoPlayer;         // Reference to the VideoPlayer component
    public double loopStartTime;            // The time in seconds where you want the loop to start

    private bool videoFinished = false;     // Flag to track if the video has finished playing

    private void Start()
    {
        // Subscribe to the loopPointReached event with the OnLoopPointReached method
        videoPlayer.loopPointReached += OnLoopPointReached;

        videoPlayer.loop = false;            // Set initial loop mode to false (to play only once)
        videoPlayer.Play();                  // Start playing the video
    }

    private void Update()
    {
        // Check if the video has finished playing and is not currently playing
        if (!videoFinished && !videoPlayer.isPlaying)
        {
            videoFinished = true;                  // Set the videoFinished flag to true
            videoPlayer.time = videoPlayer.clip.length - 5; // Start at the last 5 seconds of the video
            videoPlayer.loop = true;               // Enable loop mode
            videoPlayer.Play();                    // Start playing again from the last 5 seconds
        }
    }

    private void OnLoopPointReached(VideoPlayer player)
    {
        // This method is called when the video's loop point is reached

        if (videoFinished)
        {
            player.time = loopStartTime;  // Restart the loop from the specified loopStartTime
        }
    }
    */
}