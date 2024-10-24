using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelHolderErrorMessage : MonoBehaviour
{
    public GameObject errorMessage;
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            errorMessage.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            errorMessage.SetActive(false);
        }
    }
}
