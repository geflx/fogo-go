using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubiGasScript : MonoBehaviour
{
	public GameObject LevelComplete;

    void OnTriggerEnter2D(Collider2D collision){
        LevelComplete.SetActive(true);    

        Destroy(gameObject);   
    }
}
