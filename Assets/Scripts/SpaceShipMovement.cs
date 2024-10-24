using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{

    public float speed = 5f;
    public float HopSpeed = 15f;
    private bool isRight = true; // To track if the player is rotated
    public Rigidbody2D rb;
    public Transform tf;
    float resultantVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = new Vector2(0f , rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                tf.localScale = new Vector3(Mathf.Abs(tf.localScale.x), tf.localScale.y, tf.localScale.z);
                isRight = true;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
            else
            {
                
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                tf.localScale = new Vector3((isRight ? -1 : 1) * tf.localScale.x, tf.localScale.y, tf.localScale.z);
                isRight = false;
            }
            //tf.localScale = new Vector3((isRight ? -1 : 1) * tf.localScale.x, tf.localScale.y, tf.localScale.z);


        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = new Vector2( rb.velocity.x , 0f);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, speed);
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.RightShift))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
        }
        if (Input.GetKey(KeyCode.L))
        {
            resultantVelocity = (tf.localScale.x > 0) ? Mathf.Abs(rb.velocity.x) + HopSpeed : rb.velocity.x - HopSpeed;
            rb.velocity = new Vector2(resultantVelocity, rb.velocity.y);
        }

    }
}

