using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public string bulletTag = "RedLaser";
    public GameObject bullet;
    public float timeInterval = 1f;
    public Transform attackPoint;
    //public RandomSoundPlayer sound;


    void Start()
    {
        
        //bullet = GameObject.FindGameObjectWithTag(bulletTag);
        attackPoint = GetComponent<Transform>();
        
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {

            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        while (true) {
            Instantiate(bullet, new Vector3(attackPoint.position.x , attackPoint.position.y , attackPoint.position.z), Quaternion.identity);
            //sound.UpdateSound();
            yield return new WaitForSeconds(timeInterval);          //have to wite a script to bullet if it touches player health of player reduced
        }
    }
}
