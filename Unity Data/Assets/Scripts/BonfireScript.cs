using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireScript : MonoBehaviour{
   
    private GameObject Player;
    private float destroyTimer;
    private Animator animator;
    private bool destroyed;

    public GameObject bonfire;

    void Start(){
        Player = GameObject.Find("Player");

        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("destroyed", false);

        destroyed = false;
        destroyTimer = 1.0f;
    }

    void Update(){
        if(destroyed)
        	if(destroyTimer > 0.0f)
        		destroyTimer -= Time.deltaTime;
        	else
        		Destroy(gameObject);        
    }

     void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            Destroy(gameObject.GetComponent<BoxCollider2D>());

            if(!destroyed){
            	Debug.Log("Touched bonfire.");

            	animator.SetBool("destroyed", true);
                Player.GetComponent<Health>().health -=1;

            	destroyed = true;
            }
        }
    }
}
