using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 500f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-speed, 0f));
        //Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collidedObj)
    {
        if (collidedObj.gameObject.tag == "Player")
        {
            Debug.Log("Collision detected with: " + collidedObj.gameObject.name);
            Rigidbody2D orb = collidedObj.gameObject.GetComponent<Rigidbody2D>();
            orb.AddForce(new Vector2(-50f, 10f));
        }
    }
  
}
