using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    [Header("<-----Boost System----->")]
    public float boost = 100f; // Updated variable name.
    public float currentBoost; // Updated variable name.
    public float regenAmount = 40;
    [Header("<---- Damage Rates----->")]
    public float degenSpeed = 5f;
    
    public Image boostBar; // Updated variable name.

    // Start is called before the first frame update
    void Start()
    {
        currentBoost = boost; 
    }

    // Update is called once per frame
    void Update()
    {
        Degenerate();
    }


    public void Degenerate()
    {
        if (currentBoost > 0) // Updated variable name.
        {
            currentBoost -= degenSpeed * Time.deltaTime;
            boostBar.fillAmount = currentBoost / 100f;
        }
    }

    public void Regenerate(float amount)
    {
        currentBoost += amount; // Updated variable name.
        currentBoost = Mathf.Clamp(currentBoost, 0f, boost); // Ensure boost doesn't exceed the maximum.
        boostBar.fillAmount = currentBoost / 100f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Boost")) 
        {
            Regenerate(regenAmount); // Updated variable name.
        }
    }
}
