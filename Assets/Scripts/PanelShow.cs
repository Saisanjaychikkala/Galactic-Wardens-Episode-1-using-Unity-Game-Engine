using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelShow : MonoBehaviour
{
    public GameObject panel;
    [Header("---Level BuildIndex----")]
    public int index;
    public LevelNav planet;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered Mars");
            panel.SetActive(true);
            planet.SetLevelIndex(index); // Pass the index to LevelNav
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exited Mars");
            panel.SetActive(false);
        }
    }
}
