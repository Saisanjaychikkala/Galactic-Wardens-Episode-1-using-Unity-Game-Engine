using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRocksBehaviour : MonoBehaviour
{
    public string[] possibleFunctions = new string[] { "Explode", "SetGravity", "Gift" };
    public GameObject[] gifts;
    [Header("Explosion Prefab")]
    public GameObject explosion;

    private void Start()
    {
        int randomIndex = Random.Range(0, possibleFunctions.Length);
        string randomFunctionName = possibleFunctions[randomIndex];
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            int randomIndex = Random.Range(0, possibleFunctions.Length);
            string randomFunctionName = possibleFunctions[randomIndex];
            Invoke(randomFunctionName, 0f);
        }
    }

    private void Explode()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(exp, 0.25f);
        Destroy(gameObject, 0.1f);
    }

    private void SetGravity()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void Gift()
    {
        if (gifts.Length > 0)
        {
            int randomGiftIndex = Random.Range(0, gifts.Length);
            Vector3 spawnPosition = transform.position; // You can adjust this position as needed.
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(gifts[randomGiftIndex], spawnPosition, spawnRotation);
        }
    }
}
