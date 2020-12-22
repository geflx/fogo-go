using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinScore : MonoBehaviour
{
    public TextMeshProUGUI coinDisplay;
    public GameObject Player;

    void Start(){
        Player = GameObject.Find("Player");
    }
    void Update(){
    	int coins = Player.GetComponent<Player>().coins;

        // 10 coins == +1 HP.
        if(coins == 3){
        	coins = Player.GetComponent<Player>().coins = 0;
        	Player.GetComponent<Health>().health++;
        }

        coinDisplay.text = coins.ToString();
    }
    
}
