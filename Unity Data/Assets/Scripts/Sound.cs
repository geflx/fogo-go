using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource[] sources;

    public bool thriller, gameplay, spring, coin;

    void Start(){
        thriller = false;
        gameplay = false;
        spring = false;
        coin = false;
    }

    void Update(){
        if(thriller){

            sources[1].Pause();
            sources[0].Play();
            gameplay = false;
            thriller = false;

        }else if(gameplay){

            sources[0].Pause();
            sources[1].Play();
            thriller = false;
            gameplay = false;
        }else if(spring){
            sources[2].Play();
            spring = false;
        }else if(coin){
            sources[3].Play();
            coin = false;
        }
    }
}
