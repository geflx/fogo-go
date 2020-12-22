using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //important

public class Health : MonoBehaviour
{
    public int health, numOfHearts, oldHealth;
    public Image[] hearts;
    public Sprite fullHeart, emptyHeart;
    public GameObject Player;

    float blinkTimer = -1.0f, blinkTime = 0.3f;
    int contBlink = 0;

    void Start(){
        Player = GameObject.Find("Player");
        oldHealth = numOfHearts;
    }

    void damageBlink(){
        if(oldHealth > health){
            contBlink = 5;

            // Set player to blink as well.
            Player.GetComponent<Player>().blinkCount = 8;
        }

        oldHealth = health;

        // If blinkTimer is lower than -blinkTime, reset timer.
        if(blinkTimer <= -blinkTime && contBlink > 0){
            contBlink--;
            blinkTimer = blinkTime;
        }
    }
 
    void Update(){

        // Hearts limit = 3.
        if(health > numOfHearts)
            health = numOfHearts;        

       damageBlink();
       blinkTimer -= Time.deltaTime;

        for(int i = 0; i < hearts.Length; i++){

            if(i < health){
                // If contBlink !=0, it means that the blink function is enabled.
                if(blinkTimer > 0.0f && contBlink != 0)
                    hearts[i].sprite = emptyHeart;
                else
                    hearts[i].sprite = fullHeart;
            }
            else{
                hearts[i].sprite = emptyHeart;            
            }

            if(i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
