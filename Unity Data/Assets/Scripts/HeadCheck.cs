using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour
{
    private GameObject Lumberjack;

    void Start(){
        Lumberjack = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Player")
            Lumberjack.GetComponent<Lumberjack>().dead = true;
    }  
}
