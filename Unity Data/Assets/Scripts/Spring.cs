using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
	public Animator anim;
	private GameObject player, soundManager;

    void Awake(){
        player = GameObject.Find("Player");
        soundManager = GameObject.Find("SoundManager");
    }
	void OnTriggerEnter2D (Collider2D other){
         if(other.name == "Player")
         {
         	player.GetComponent<Player>().springJump = true;
        	anim.SetBool("PlayAnim", true);
            soundManager.GetComponent<Sound>().spring = true;
    	}
    }

    void FixedUpdate(){
        	anim.SetBool("PlayAnim", false);
    }

}
