using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : MonoBehaviour
{

    private GameObject Player;
    public float playerDistance;
    public float moveSpeed;

    private Animator animator;
    private BoxCollider2D myBoxCollider2D;
    private Rigidbody2D myRigidbody2D;

    public float delayToCheck;
    private float waitingDelay;
    private float destroyTimer;
    private int direction;

    public bool run, dead, destroyTimerActive;

    
    void Start(){
        run = false;
        dead = false;
        destroyTimerActive = false;

        direction = -1;
        destroyTimer = 1.0f;
        waitingDelay = delayToCheck;

        Player =  GameObject.Find("Player");
        animator = GetComponent<Animator>();

        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        playerDistance = Mathf.Abs(Player.transform.position.x - gameObject.transform.position.x);

        if(playerDistance <= 11.5f)
            run = true;
                
        if(Player.transform.position.x - gameObject.transform.position.x  > 20 )
            Destroy(gameObject);
        
        if(dead){
            moveSpeed = 0;
            destroyTimerActive = true;
            animator.SetBool("dead", true);
            Destroy(myBoxCollider2D);
            Destroy(myRigidbody2D);

            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }

            dead = false;
        }

        if(destroyTimerActive){
        	if(destroyTimer >= 0.0f)
        		destroyTimer -= Time.deltaTime;
        	else
        		Destroy(gameObject);
        }

        if(run){
            if(waitingDelay > 0){
                waitingDelay -= Time.deltaTime;
            }else{
                if((Player.transform.position.x - gameObject.transform.position.x) < 0)
                    direction = -1;
                else
                    direction = 1;

                waitingDelay = delayToCheck;
            }
            Move(direction);
        }
       
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag != "Player"){
            if(direction == -1)
                direction = 1;
            else 
                direction = -1;
        }
    }

    void Move(int direction){
        if(direction == -1){
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }else{
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
    }
}
