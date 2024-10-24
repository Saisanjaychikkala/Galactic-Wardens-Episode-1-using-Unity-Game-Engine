using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCollectable : MonoBehaviour
{
    public float time = 0.1f;
    

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, time);
        }
    }
    /*void OnTriggerExit2D(Collider2D obj)
    {
        if (gameObject.CompareTag("Oxyzen"))
        {
            //OxyzenBarIncrease()
        }
        else if (gameObject.CompareTag("Boost"))
        {
            //BoostBarIncrease()
        }
        else if (gameObject.CompareTag("Parts"))
        {
            //PartsCollected()
            
        }

    }
    public void OxyzenBarIncrease()
    {

    }
    public void BoostBarIncrease()
    {

    }
    public void PartsColleected()
    {
        //textMeshProComponent.text = "Your new text goes here";
    }*/
}
