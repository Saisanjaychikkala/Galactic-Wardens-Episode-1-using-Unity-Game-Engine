using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistHouse : MonoBehaviour
{
    //gg
    public GameObject ConvoPanel;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.CompareTag("Player")){
            obj.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f , 0f, 0f);
            ConvoPanel.SetActive(true);
        }
    }

   
}
