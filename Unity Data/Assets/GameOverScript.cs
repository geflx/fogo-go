using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
	public GameObject indicatorManager, player, gameOverScreen;

    void Update(){
    	if(player.GetComponent<Health>().health == 0){
    		indicatorManager.GetComponent<Indicator>().active = false;
    		gameOverScreen.SetActive(true);
    		player.SetActive(false);
    	}   
    }
}
