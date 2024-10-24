using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tf;
    [Header("small boost")]
    public float up = 1f;
    public float right = 1f;
    [Header("shift boost")]
    public float boost = 5f;
    [Header("angle")]
    public float posRot = 10f;
    public float negRot = 10f;
    public bool isGravity = false;
    [Header("Gravity On")]
    public float speed = 10f;
    public float jumpSpeed = 10f;
    public float time = 30f;
    public int jumpCount = 3;
    public Animator anim;
    private bool isMoving = false;
    private bool isRight = true; // To track if the player is rotated

    void Start()
    {
        // Get references to Rigidbody2D and Transform
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            isGravity = true;
            rb.gravityScale = 1f;
            rb.constraints |= RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("isIdle", true);
            StartCoroutine(antiGravity());
        }
        if (isGravity)
        {
            
            if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
            {
                anim.SetTrigger("isJump");
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumpCount -= 1;
            }
            
        }
        

        
    }
    void FixedUpdate()
    {
        
        
        if (isGravity)
        {
            isMoving = false;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                isMoving = true;
                anim.SetBool("isIdle", false);
                anim.SetBool("isRun", true);
                rb.velocity = new Vector2(speed, rb.velocity.y);
                tf.localScale = new Vector3(Mathf.Abs(tf.localScale.x), tf.localScale.y, tf.localScale.z);
                isRight = true;
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                isMoving = true;
                anim.SetBool("isIdle", false);
                anim.SetBool("isRun", true);
                tf.localScale = new Vector3((isRight?-1:1) * tf.localScale.x, tf.localScale.y, tf.localScale.z);
                
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                isRight = false;
            }
            
            if (!isMoving)
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isRun", false);
            }
            //anim.SetBool("isRun", false);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0f, boost));
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(boost , 0f));
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2( -boost , 0f));
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2( 0f, -boost));
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0f, up));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(right, 0f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-right, 0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0f, -up));
        }
        if (Input.GetKey(KeyCode.E))
        {
            tf.Rotate(new  Vector3(0f, 0f, 1f), -(negRot));
            //rb.angularVelocity = 10f;
            /* Toggle rotation
            isRotated = !isRotated;

            // Rotate the player's body
            if (isRotated)
            {
                tf.rotation = Quaternion.Euler(0f, 0f, 90f); // Rotate by 90 degrees
            }
            else
            {
                tf.rotation = Quaternion.identity; // Reset rotation
            }
            */
        }
        if (Input.GetKey(KeyCode.Q))
        {
            tf.Rotate(new Vector3(0f, 0f, 1f), posRot);
        }
    }

    IEnumerator antiGravity()
    {
        yield return new WaitForSeconds(time);
        isGravity = false;
        rb.gravityScale = 0f;
        rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
        anim.SetTrigger("isFloat");
        //anim.SetBool("isRun", false);
        //anim.SetBool("isIdle", false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor")
        {
            jumpCount = 3;
        }
    }
}
