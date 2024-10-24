using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorChecking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("mello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hello");
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("cello");
        }
    }
}
