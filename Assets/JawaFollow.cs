using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawaFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform jawaTf , playerTf;
    public Vector3 offset;
    bool flag = false;
    public float timeBeforeFollow =  1f;
    void Start(){
        flag = false;
    }
    void OnTriggerExit2D(Collider2D obj){
        if(obj.gameObject.CompareTag("Player")){
            //StartCoroutine(follow());
            flag = true;
        }
    }
    void Update(){
        if(flag == true){
            jawaTf.position = playerTf.position +  offset ;
        }
    }

    IEnumerator follow(){
        yield return new WaitForSeconds(timeBeforeFollow);
        jawaTf.position = playerTf.position +  offset ;
        StartCoroutine(follow());
    }
}
