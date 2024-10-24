using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowOwn : MonoBehaviour
{
    public Transform tf;
    public float zpos = 10f;
    public float yoffset = 10f;

    void Update()
    {
        Vector3 newpos = new Vector3(tf.position.x, tf.position.y + yoffset, -(zpos));
        transform.position = newpos;
    }
}

