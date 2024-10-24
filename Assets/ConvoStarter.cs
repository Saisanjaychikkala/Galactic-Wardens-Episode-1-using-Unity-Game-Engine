using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoStarter : MonoBehaviour
{
    // Start is called before the first frame update
    public int times =1;
    public GameObject panel;
    

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.CompareTag("Player") && times > 0){
            panel.SetActive(true);
            times -= 1;
        }
    }
}
