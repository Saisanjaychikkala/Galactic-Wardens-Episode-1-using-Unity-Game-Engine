using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    public GameObject Story;
    public GameObject cut_Scene;
    public GameObject player;
    int times = 0;
     // The story object to activate/deactivate
    //public Camera mainCamera; // Your main camera
    //public Camera secondaryCamera; // The secondary camera to switch to
    //public float switchDuration = 2.0f; // Duration to switch to the secondary camera (in seconds)
    //public float returnDuration = 2.0f; // Duration to return to the main camera (in seconds)

    //private bool isSwitching = false;
    void Start(){
        times = 0;
    }
    void Action(){
        if(times < 1){
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Story.SetActive(true);
            cut_Scene.SetActive(true);
            times += 1;
        }
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player") )
        {
            
            Action();
            
        }
    }

    /*void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            // Deactivate the story object
            Story.SetActive(false);
        }
    }*/

    /*IEnumerator SwitchCameras()
    {
        isSwitching = true;

        // Disable the main camera
       // mainCamera.enabled = false;
        //secondaryCamera.SetActive(true);
        // Enable the secondary camera
        secondaryCamera.enabled = true;

        // Wait for the switch duration
        yield return new WaitForSeconds(switchDuration);

        // Disable the secondary camera
        secondaryCamera.enabled = false;

        // Enable the main camera again
        mainCamera.enabled = true;

        // Wait for the return duration
        yield return new WaitForSeconds(returnDuration);

        isSwitching = false;
    }*/
}
