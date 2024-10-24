using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private float moveSpeed;
    private bool moveRight;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(float speed, bool isMovingRight)
    {
        moveSpeed = speed;
        moveRight = isMovingRight;

        // Flip the sprite if moving left
        if (!moveRight)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1f;
            transform.localScale = newScale;
        }
    }

    private void Update()
    {
        // Determine the direction of movement
        float horizontalMovement = moveRight ? 1f : -1f;

        // Move the NPC horizontally
        Vector2 movement = new Vector2(horizontalMovement * moveSpeed, rb2d.velocity.y);
        rb2d.velocity = movement;
    }
}
