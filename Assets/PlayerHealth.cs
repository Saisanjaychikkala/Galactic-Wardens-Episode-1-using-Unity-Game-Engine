using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("<-----Health System----->")]
    public float health = 100f;
    public float currentHealth;
    public float regenSpeed = 3f;
    public GameObject player;
    [Header("<---- Damage Rates----->")]
    public float redLaserDamage = 6;
    public float FlyingDroidDamage = 12;
    public float ExplosionDamage = 25f;

    public GameObject mainMenu;
    public Image healthBar;
    //public Image menubg;
    // Start is called before the first frame update
    void Start()
    {
        //menubg.SetActive(false);
        mainMenu.SetActive(false);
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Regenerate();
        if(currentHealth  <= 0)
        {
            player.SetActive(false);
            //Destroy(gameObject, 3f);
            //menubg.SetActive(true);
            mainMenu.SetActive(true);
        }
    }

    public void DamagePlayer(float damage)
    {
        //Debug.Log("taking damage");
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;
    }
    public void Regenerate()
    {
        if(currentHealth < 100 - regenSpeed)
        {
            currentHealth += regenSpeed * Time.deltaTime;
            healthBar.fillAmount = currentHealth / 100f;
        }
    }
    void OnTriggerEnter2D(Collider2D laser)
    {
        if (laser.gameObject.CompareTag("RedLaser"))
        {
            DamagePlayer(redLaserDamage);
        }
        if (laser.gameObject.CompareTag("FlyingDroid"))
        {
            DamagePlayer(FlyingDroidDamage);
        }
        if (laser.gameObject.CompareTag("Explosion"))
        {
            DamagePlayer(ExplosionDamage);
        }
    }
}
