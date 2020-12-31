using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTypeTrigger : MonoBehaviour
{

    public bool finished = false;

    public GameObject DialogManager;
    public GameObject DialogCanvas;

    public GameObject indicators;
    public GameObject buttons;

    public GameObject player;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player" && !finished){
            DialogManager.SetActive(true);
            DialogCanvas.SetActive(true);
            indicators.SetActive(true);
            buttons.SetActive(true);
            Debug.Log("hi2");

            Destroy(gameObject.GetComponent<BoxCollider2D>());
            finished = true;
            player.SetActive(false);
            for(int i = 0; i < 100; i++){
            	//
            }
            player.SetActive(true);
        }
    }
}
