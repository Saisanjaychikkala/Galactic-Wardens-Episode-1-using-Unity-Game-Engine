using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Death : MonoBehaviour
{
    // S
    public float deathtime = 0f;
    void OnTriggerEnter2D(Collider2D obj)
    {
        //Debug.Log("collidied with: " + obj.gameObject.name);
        if (obj.gameObject.CompareTag("FlyingDroid") || obj.gameObject.CompareTag("Floor"))
        {
            //playerHealth.DamagePlayer(damagerate);
            Destroy(gameObject,deathtime);

        }


    }
}
