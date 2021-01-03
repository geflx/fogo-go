using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
	private GameObject soundManager, indicatorManager, player;

	private float durationTimer = 14.0f;

    void Start(){
        soundManager = GameObject.Find("SoundManager");
        indicatorManager = GameObject.Find("IndicatorManager");
        player = GameObject.Find("Player");

        player.GetComponent<Player>().freeze = true;
        soundManager.GetComponent<Sound>().win = true;
        indicatorManager.GetComponent<Indicator>().active = false;
    }

    void Update(){
        
    	if(durationTimer >= 0.0f){
    		durationTimer -= Time.deltaTime;
    	}else{
       		SceneManager.LoadScene("Levels");
    	}
    }
}
