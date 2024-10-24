using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip[] soundClips; // Array of sound clips to choose from

    public bool isPlaying = false; // Flag to track if a sound is currently playing
    public float timeInterval = 4f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on this GameObject
    }

    void Update()
    {
        if (!isPlaying) // Check if a sound is not currently playing
        {
            PlayRandomSound(); // If not, play a random sound
        }
    }

    public void UpdateSound()
    {
        isPlaying = true;
    }

    void PlayRandomSound()
    {
        if (soundClips.Length > 0)
        {
            int randomIndex = Random.Range(0, soundClips.Length); // Choose a random index from the array
            audioSource.clip = soundClips[randomIndex]; // Set the AudioClip to the chosen sound
            audioSource.Play(); // Play the sound
            isPlaying = true; // Set the flag to indicate that a sound is playing

            // Wait until the sound has finished playing
            StartCoroutine(WaitForSoundToFinish());
        }
        else
        {
            Debug.LogWarning("No sound clips assigned to the array.");
        }
    }

    IEnumerator WaitForSoundToFinish()
    {
        yield return new WaitForSeconds(audioSource.clip.length + timeInterval);
        isPlaying = false; // Reset the flag when the sound is done playing
    }
}
