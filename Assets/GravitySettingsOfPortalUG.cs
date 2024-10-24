using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySettingsOfPortalUG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //ss
    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = obj.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.gravityScale = 1;
            }
        }    
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = obj.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.gravityScale = 0;
            }
        }
    }
}
