using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    void Start()
    {
        destination.position = new Vector3(destination.position.x,destination.position.y +10, destination.position.z);
    }
    public Transform GetDestination()
    {

        return destination;
    }
}
