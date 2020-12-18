﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimiter : MonoBehaviour
{
    public GameObject Player;
    public GameObject indicator;
    
    public GameObject indicatorStatus;

    private float checkAgain;

    void Start(){
        Player = GameObject.Find("Player");
        indicator = GameObject.Find("RightIndicator");
        indicatorStatus = GameObject.Find("IndicatorManager");

        checkAgain = 0;
    }

    // Update is called once per frame
    void Update(){
        
        if(indicatorStatus.GetComponent<Indicator>().active == true){
            if(checkAgain <=0.0 && Mathf.Abs(Player.transform.position.x - transform.position.x) < 5){
                indicator.GetComponent<Blink>().blink = true;
                checkAgain = 2.0f;
            }else{
                checkAgain -= Time.deltaTime;
            }
        }
    }
}
