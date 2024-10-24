using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject asteroidPrefab; // Corrected variable name
    public float time = 5f;
    public float from, to;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(asteroidPrefab, time)); // Use StartCoroutine to start the coroutine
    }
    void Update()
    {
        from = player.transform.position.x + 10;
        to = player.transform.position.x + 100;
    }

    IEnumerator Spawn(GameObject rock, float time)
    {
        Instantiate(rock, new Vector2(Random.Range(from ,to ), 0f), Quaternion.identity);
        yield return new WaitForSeconds(time); // Corrected WaitforSeconds to WaitForSeconds
        StartCoroutine(Spawn(rock, time)); // Start the coroutine again with the same parameters
    }
}
