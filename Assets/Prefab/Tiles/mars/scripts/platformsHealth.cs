using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformsHealth : MonoBehaviour
{
    [Header("<-----Health System----->")]
    public float health = 100f;
    public float currentHealth;
    public float regenSpeed = 0.1f;

    [Header("<---- Damage Rates----->")]
    public float blueLaserDamage = 20;
    [Header("Explosion Prefab")]
    public GameObject explosion;
    void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        Regenerate();
        if (currentHealth <= 0)
        {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp ,0.25f);
            Destroy(gameObject, 0.1f);
        }
    }

    public void DamagePlayer(float damage)
    {
        currentHealth -= damage;
        // Uncomment and configure your health bar if needed.
        // healthBar.fillAmount = currentHealth / health;
    }

    public void Regenerate()
    {
        if (currentHealth < health - regenSpeed)
        {
            currentHealth += regenSpeed * Time.deltaTime;
            // Uncomment and configure your health bar if needed.
            // healthBar.fillAmount = currentHealth / health;
        }
    }

    void OnTriggerEnter2D(Collider2D laser)
    {
        if (laser.gameObject.CompareTag("BlueLaser"))
        {
            DamagePlayer(blueLaserDamage);
        }
    }
}
