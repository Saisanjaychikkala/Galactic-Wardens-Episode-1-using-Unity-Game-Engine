using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            if(currentTeleporter != null)
            {
                
                transform.position = currentTeleporter.GetComponent<teleporter>().GetDestination().position;
                Physics2D.gravity = new Vector2(0f, -9.8f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            
            currentTeleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
               
                currentTeleporter = null;
            }
        }
    }
}

