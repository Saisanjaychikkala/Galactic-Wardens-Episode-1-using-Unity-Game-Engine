using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;  // Import the A* package namespace

public class AutomaticPathfinding : MonoBehaviour
{
    public AstarPath astarPath;  // Reference to the A* Pathfinder component


    void Start()
    {
        ScanNavigationGraph();  // Call the scan function when the game starts
    }

    // Method to trigger the scan
    void ScanNavigationGraph()
    {
        if (astarPath != null)
        {
            astarPath.Scan();  // Trigger the scan function
        }
        else
        {
            Debug.LogError("AstarPath component not assigned!");
        }
    }
}
