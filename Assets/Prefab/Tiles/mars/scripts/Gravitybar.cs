using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gravitybar : MonoBehaviour
{
    [Header("<-----Gravity System----->")]
    public float time = 30f;
    public float currentTime;
    public float decrementRate = 1f; // Rate at which gravity decreases per second.
    public bool isDecreasing = false;
    [Header("<---- Gravity Bar----->")]
    public Image gravityBar;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentTime = time;
            gravityBar.fillAmount = 1f;
            isDecreasing = true;
        }
        if (isDecreasing)
        {
            DecreaseGravity();
        }
        if (currentTime < 0)
        {
            isDecreasing = false;
            RegenerateGravity();

        }
    }

    void DecreaseGravity()
    {
        if (currentTime > 0)
        {
            currentTime -= decrementRate * Time.deltaTime;
            gravityBar.fillAmount = currentTime / time;
        }
    }

    void RegenerateGravity()
    {
        currentTime = time;
        gravityBar.fillAmount = 1f;
    }
}
