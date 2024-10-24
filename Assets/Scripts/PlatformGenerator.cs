using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectPlacer : MonoBehaviour
{
    public Transform tf;
    public float startRangeX = 49.9f;
    public float endRangeX = 1169f;
    public float startRangeY = 167.9f;
    public float endRangeY = 277f;
    public GameObject[] objectPrefabs;
    public float divisionSize = 30f;

    void Awake()
    {
        tf = GetComponent<Transform>();
        startRangeX = tf.position.x;
        startRangeY = tf.position.y;
        GenerateObjects();
    }

    void GenerateObjects()
    {
        foreach (float x in GetDivisionPoints(startRangeX, endRangeX, divisionSize))
        {
            foreach (float y in GetDivisionPoints(startRangeY, endRangeY, divisionSize))
            {
                Vector3 position = new Vector3(x + Random.Range(0f, divisionSize), y + Random.Range(0f, divisionSize), -1.5f);
                GameObject selectedPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
                GameObject instantiatedObject = Instantiate(selectedPrefab, position, Quaternion.identity);

                // Set the layer of the instantiated object to "Obstacle"
                instantiatedObject.layer = LayerMask.NameToLayer("Obstacle");
            }
        }
    }

    IEnumerable<float> GetDivisionPoints(float start, float end, float division)
    {
        for (float value = start; value <= end; value += division)
        {
            yield return value;
        }
    }
}
