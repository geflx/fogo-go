using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Collider2D myCollider;
    private GameObject soundManager, player;

    void Start(){
    	soundManager = GameObject.Find("SoundManager");
    	player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){

            //other.GetComponent<Player>().coins++;
            player.GetComponent<Player>().coins++;
            
            myCollider.enabled = false;
            soundManager.GetComponent<Sound>().coin = true;
            Destroy(transform.parent.gameObject);
        }
    }
}
