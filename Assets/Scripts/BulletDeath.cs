using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20;  // Constant speed magnitude
    public Transform playerTf;
    public float deathtime = 0.5f;
    //public PlayerHealth playerHealth;
    public float damagerate = 5f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTf = player.transform;

        // Calculate direction towards the player
        Vector2 direction = (playerTf.position - transform.position).normalized;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;  // Set velocity directly instead of using AddForce
        
    }
    //what amma what is this amma
    void OnTriggerEnter2D(Collider2D obj)
    {
        //Debug.Log("collidied with: " + obj.gameObject.name);
        if (obj.gameObject.CompareTag("Player") || obj.gameObject.CompareTag("Floor") )
        {
            //playerHealth.DamagePlayer(damagerate);
            Destroy(gameObject, deathtime);
            
        }

        
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        //Debug.Log("collidied with: " + obj.gameObject.name);
        if (obj.gameObject.CompareTag("Horizon"))
        {
            //playerHealth.DamagePlayer(damagerate);
            Destroy(gameObject, deathtime);
            
        }

        
    }
    void OnCOllisionEnter2D(Collider2D obj){
        if (obj.gameObject.CompareTag("Player") || obj.gameObject.CompareTag("Floor") ||obj.gameObject.CompareTag("Horizon") )
        {
            //playerHealth.DamagePlayer(damagerate);
            Destroy(gameObject, deathtime);
            
        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{
    public Rigidbody2D rb;  // Corrected variable name
    public float xSpeed = 20, ySpeed = 20;
    public Transform playertf;
    public float deathtime = 0.5f;
    public float distx , disty;

    void Start()
    {
        GameObject pla = GameObject.FindGameObjectWithTag("Player");
        playertf = pla.transform;
        xSpeed = (- playertf.position.x + transform.position.x) / 2  ;
        ySpeed = (-playertf.position.y + transform.position.y) / 2;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(xSpeed, ySpeed));  // Corrected force application
    }

    
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))  // Added closing parenthesis
        {
            // Call health function of player
        }
        Destroy(gameObject, deathtime);
    }
}*/
