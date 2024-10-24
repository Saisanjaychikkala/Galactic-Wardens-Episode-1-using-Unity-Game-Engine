using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSoundSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    //SpawnRandomNPCs npc;
    void Start()
    {
        gameObject.GetComponent<SpawnRandomNPCs>().enabled = false;
    }
    void OnTriggerEnter2D(Collider2D obj){
        if(obj.gameObject.CompareTag("Player")){
            gameObject.GetComponent<SpawnRandomNPCs>().enabled = true;
        }
    }

   
}
