using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
	public Animator anim;
	public GameObject player, soundManager;

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
