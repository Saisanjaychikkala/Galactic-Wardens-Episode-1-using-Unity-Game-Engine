using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Camera cam;
    public Transform subject;
    Vector2 startingPosition;
    float startingZ;
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    float zDistanceFromTarget => transform.position.z - subject.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;



    private void Awake()
    {
        // Cache the Camera and Subject references if they are not assigned
        if (cam == null)
            cam = Camera.main;

        if (subject == null)
        {
            GameObject playerz = GameObject.FindWithTag("Player");
            subject = playerz.transform; // Replace with your player's script or object
        }
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
