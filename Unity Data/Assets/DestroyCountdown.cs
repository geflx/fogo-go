using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCountdown : MonoBehaviour
{
	public float destroyTimer;

    void Update(){
    	destroyTimer -= Time.deltaTime;
    	if(destroyTimer <= 0.0f)
    		Destroy(gameObject);        
    }
}
