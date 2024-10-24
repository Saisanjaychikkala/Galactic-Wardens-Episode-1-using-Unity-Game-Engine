using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndScript : MonoBehaviour
{
    public GameObject assemble;
    public int levelIndex;
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            assemble.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            assemble.SetActive(true);
        }
    }

    public void Assemble()
    {
        SceneManager.LoadScene(levelIndex);
    }
    //abracadabra
}
