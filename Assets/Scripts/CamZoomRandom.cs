using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamZoomRandom : MonoBehaviour
{

    public CinemachineVirtualCamera virtualCamera; // Reference to your Cinemachine Virtual Camera
    public float minZoomedInSize; // The minimum size of the camera when zoomed in
    public float maxZoomedInSize; // The maximum size of the camera when zoomed in
    public float originalSize;   // The original size of the camera
    public float zoomSpeed = 2f; // The speed at which the camera zooms
    public float changeInterval = 5f; // Time interval for changing the camera size

    private float timeSinceLastChange = 0f;
    private bool zoom = false;
    private float currentTargetSize;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        RandomizeZoomTarget();
    }

    void Update()
    {
        // Update the timer
        timeSinceLastChange += Time.deltaTime;

        // Check if it's time to change the camera size
        if (timeSinceLastChange >= changeInterval)
        {
            RandomizeZoomTarget();
            timeSinceLastChange = 0f;
        }

        // Smoothly interpolate to the current target size
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, currentTargetSize, Time.deltaTime * zoomSpeed);
    }

    void RandomizeZoomTarget()
    {
        float randomSize = Random.Range(minZoomedInSize, maxZoomedInSize);
        currentTargetSize = zoom ? randomSize : originalSize;
        zoom = !zoom;
    }
}
