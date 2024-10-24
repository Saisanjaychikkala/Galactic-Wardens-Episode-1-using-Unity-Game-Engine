using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("<-----Health System----->")]
    public float health = 100f;
    public float currentHealth;
    public float regenSpeed = 3f;
    [Header("<---- Damage Rates----->")]
    public float blueLaserDamage = 6;
    [Header("<---MainMenuPanel-->")]
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(false);
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Regenerate();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            mainMenu.SetActive(true);
        }
    }

    public void DamageDroid(float damage)
    {
        currentHealth -= damage;
    }
    public void Regenerate()
    {
        if (currentHealth < 100 - regenSpeed)
        {
            currentHealth += regenSpeed * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D laser)
    {
        if (laser.gameObject.CompareTag("BlueLaser"))
        {
            DamageDroid(blueLaserDamage);
        }
    }
}
