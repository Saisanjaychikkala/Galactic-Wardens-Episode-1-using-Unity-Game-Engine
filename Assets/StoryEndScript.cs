using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEndScript : MonoBehaviour
{
    public GameObject enemy1, enemy2, jawa1, jawa2, targetPos, player, portalStart;
    public float moveSpeed = 2.0f; // Adjust this to control the movement speed
    public float teleportThreshold = 0.1f; // Adjust this threshold for teleportation

    private bool isMovingJawa1, isMovingJawa2;

    // Start is called before the first frame update
    void Start()
    {
        isMovingJawa1 = false;
        isMovingJawa2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1 == null && enemy2 == null)
        {
            if (jawa1 != null)
            {
                /*SpriteRenderer jawa1SpriteRenderer = jawa1.GetComponent<SpriteRenderer>();
                if (jawa1SpriteRenderer != null)
                {
                    jawa1SpriteRenderer.flipX = true;
                }*/

                if (!isMovingJawa1)
                {
                    StartCoroutine(MoveJawaToTarget(jawa1));
                    isMovingJawa1 = true;
                }
            }

            if (jawa2 != null)
            {
                if (!isMovingJawa2)
                {
                    StartCoroutine(MoveJawaToTarget(jawa2));
                    isMovingJawa2 = true;
                }
            }
        }

        if (jawa1 != null && Mathf.Abs(jawa1.transform.position.x - targetPos.transform.position.x) < teleportThreshold)
        {
            Destroy(jawa1);
        }
        if (jawa2 != null && Mathf.Abs(jawa2.transform.position.x - targetPos.transform.position.x) < teleportThreshold)
        {
            Destroy(jawa2);
        }

        // Check for player teleportation
        if ( player.transform.position.x == targetPos.transform.position.x)
        {
            TeleportPlayerToStart();
        }
    }

    IEnumerator MoveJawaToTarget(GameObject jawa)
    {
        Vector3 targetPosition = targetPos.transform.position;

        while (jawa != null && Vector3.Distance(jawa.transform.position, targetPosition) > teleportThreshold)
        {
            jawa.transform.position = Vector3.MoveTowards(jawa.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    // Teleport the player to the portal start position
    void TeleportPlayerToStart()
    {
        if (portalStart != null)
        {
            Debug.Log("enteres");
                     // Maintain the same Y position
            player.transform.position = new Vector3(player.transform.position.x , portalStart.transform.position.y , player.transform.position.z); 
            Physics2D.gravity = new Vector2(0f, 9.8f);
        }
    }
}
