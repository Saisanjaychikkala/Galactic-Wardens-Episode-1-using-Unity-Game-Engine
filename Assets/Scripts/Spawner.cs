using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform player;
    public float start;
    public float end;
    public GameObject enemy;

    void Start()
    {
        start = player.position.x;
        end = player.position.x + 100;

        StartCoroutine(EnemyGenerate());
    }

    void Update()
    {
        // Update the 'from' and 'end' positions if needed
        start = player.position.x;
        end = player.position.x + 100;
    }

    IEnumerator EnemyGenerate()
    {
        while (true) // Keep generating enemies indefinitely
        {
            yield return new WaitForSeconds(10f);
            Instantiate(enemy, new Vector3(Random.Range(start, end), Random.Range(transform.position.y , transform.position.y + 20), transform.position.z), Quaternion.identity);
            
        }
    }
}
