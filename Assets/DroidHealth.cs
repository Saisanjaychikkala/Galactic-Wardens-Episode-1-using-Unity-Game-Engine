using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroidHealth : MonoBehaviour
{
    public Slider healthBar;
    [Header("<-----Health System----->")]
    public float health = 100f;
    public float currentHealth;
    public float regenSpeed = 3f;
    [Header("<---- Damage Rates----->")]
    public float blueLaserDamage = 20f;
    public float ExplosionDamage = 50f;
    [Header("Explosion Prefab")]
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.value = 1;
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Regenerate();
        if (currentHealth <= 0)
        {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 0.13f);
            Destroy(gameObject , 0.1f);
        }
    }

    public void DamageDroid(float damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth / health;
    }
    public void Regenerate()
    {
        if (currentHealth < 100 - regenSpeed)
        {
            currentHealth += regenSpeed * Time.deltaTime;
            healthBar.value = currentHealth / health;
        }
    }
    void OnTriggerEnter2D(Collider2D laser)
    {
        if (laser.gameObject.CompareTag("BlueLaser"))
        {
            DamageDroid(blueLaserDamage);
        }
        if (laser.gameObject.CompareTag("Explosion"))
        {
            DamageDroid(ExplosionDamage);
        }
        if (laser.gameObject.CompareTag("Player"))
        {
            GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(exp, 0.13f);
            Destroy(gameObject, 0.1f);
        }
    }
}
