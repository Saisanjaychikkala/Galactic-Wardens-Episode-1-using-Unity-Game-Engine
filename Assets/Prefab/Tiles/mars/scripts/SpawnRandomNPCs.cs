using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomNPCs : MonoBehaviour
{
    public GameObject npcPrefab; // The NPC prefab to spawn
    public float minY = 0f; // Minimum Y position for spawning
    public float maxY = 10f; // Maximum Y position for spawning
    public float minX = -5f; // Minimum X position for spawning
    public float maxX = 5f; // Maximum X position for spawning
    public float minSpeed = 1f; // Minimum speed of NPCs
    public float maxSpeed = 3f; // Maximum speed of NPCs

    public int numberOfNPCs = 10; // Number of NPCs to spawn

    private void Start()
    {
        SpawnNPCs();
    }

    private void SpawnNPCs()
    {
        for (int i = 0; i < numberOfNPCs; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject npc = Instantiate(npcPrefab, spawnPosition, Quaternion.identity);

            // Randomly set the speed and direction
            float speed = Random.Range(minSpeed, maxSpeed);
            bool moveRight = Random.value > 0.5f;

            // Set the speed and direction in the NPC script
            NPCMovement npcMovement = npc.GetComponent<NPCMovement>();
            if (npcMovement != null)
            {
                npcMovement.Initialize(speed, moveRight);
            }
        }
    }
}
