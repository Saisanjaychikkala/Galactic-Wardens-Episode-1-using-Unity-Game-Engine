using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    [Header("<-----Oxygen System----->")]
    public float oxygen = 100f;
    public float currentOxygen;
    public float regenAmount = 30;
    public float degenSpeed = 0.5f; // Added 'f' to make it a float.
    public GameObject player;
    [Header("<---- Damage Rates----->")]
    public float redLaserDamage = 1;
    public float flyingDroidDamage = 2; // Corrected variable name.
    public GameObject mainMenu;
    public Image oxygenBar; // Corrected variable name.

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
        currentOxygen = oxygen;
    }

    // Update is called once per frame
    void Update()
    {
        Degenerate();
        if (currentOxygen <= 0) // Corrected variable name.
        {
            player.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void DamagePlayer(float damage)
    {
        currentOxygen -= damage;
        oxygenBar.fillAmount = currentOxygen / 100f;
    }

    public void Degenerate()
    {
        if (currentOxygen > 0)
        {
            currentOxygen -= degenSpeed * Time.deltaTime;
            oxygenBar.fillAmount = currentOxygen / 100f;
        }
    }

    public void Regenerate(float amount)
    {
       
        currentOxygen += amount; // Corrected variable name.
        currentOxygen = Mathf.Clamp(currentOxygen, 0f, oxygen); // Ensure oxygen doesn't exceed the maximum.
        oxygenBar.fillAmount = currentOxygen / 100f;
    }

    void OnTriggerEnter2D(Collider2D other) // Renamed parameter to 'other' for clarity.
    {
        if (other.gameObject.CompareTag("RedLaser")) // Renamed 'laser' to 'other' for clarity.
        {
            DamagePlayer(redLaserDamage);
        }
        if (other.gameObject.CompareTag("FlyingDroid")) // Renamed 'laser' to 'other' for clarity.
        {
            DamagePlayer(flyingDroidDamage); // Corrected variable name.
        }
        if (other.gameObject.CompareTag("Oxygen")) // Corrected tag name.
        {
            
            Regenerate(regenAmount); // Corrected variable name.
        }
    }
}
