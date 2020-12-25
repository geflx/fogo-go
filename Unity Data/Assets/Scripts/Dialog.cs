using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;

    public float typingSpeed, firstCountdown = 2.0f;
    public GameObject continueButton, soundManager, indicatorManager, dialogImages;

    public GameObject dialog;

    void Start(){
        StartCoroutine(Type());

        soundManager.GetComponent<Sound>().thriller = true;
        indicatorManager.GetComponent<Indicator>().active = false;
    }

    void Update(){
        //Debug.Log("Index is: " + index + ", sentences length: " + sentences.Length + " Sentences[1] is: " + sentences[1]);
        if(textDisplay.text == sentences[index] && !continueButton.activeSelf){
            continueButton.SetActive(true);
        }
        
        // Stop playing thriller music and start gameplay.
        if(textDisplay.text == "" && index == sentences.Length - 1){
            soundManager.GetComponent<Sound>().gameplay = true;
            dialogImages.SetActive(false);
            indicatorManager.GetComponent<Indicator>().active = true;

            // Destroying objects to not interfere in other dialogs.
            Destroy(continueButton);
            Destroy(dialog);
        }
    }

    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        
        continueButton.SetActive(false);
        textDisplay.text = ""; // Clear display.
        
        if(index < sentences.Length - 1){
            index++;
            StartCoroutine(Type());
        }
    }
}
