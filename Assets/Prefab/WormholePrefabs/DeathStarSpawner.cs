using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStarSpawner : MonoBehaviour
{
    
    public float spawnTime = 10f;
    public GameObject enemy;

    void Start()
    {
       
        StartCoroutine(EnemyGenerate());
    }


    IEnumerator EnemyGenerate()
    {
        while (true) // Keep generating enemies indefinitely
        {
            Instantiate(enemy, gameObject.transform.position , Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
