using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Reference to your Cinemachine Virtual Camera
    public float zoomedInSize; // The size of the camera when zoomed in
    public float originalSize; // The original size of the camera
    public float zoomSpeed = 2f; // The speed at which the camera zooms
    //public float zoomedInScreenY; // The screen Y position when zoomed in
    //public float originalScreenY; // The original screen Y position

    private bool zoom = false;

    private Vector3 originalCameraPosition; // Store the original camera position

    private void Start()
    {
        //originalCameraPosition = virtualCamera.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            zoom = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            zoom = false;
        }
    }

    private void Update()
    {
        float targetSize = zoom ? zoomedInSize : originalSize;
        //float targetScreenY = zoom ? zoomedInScreenY : originalScreenY;

        // Use Mathf.Lerp to smoothly interpolate between current and target orthographic size
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetSize, Time.deltaTime * zoomSpeed);

        // Calculate the new camera position with updated screen Y
        //Vector3 newCameraPosition = originalCameraPosition;
        //newCameraPosition.y = targetScreenY;

        // Set the camera's position directly
        //virtualCamera.transform.position = newCameraPosition;
    }
}
