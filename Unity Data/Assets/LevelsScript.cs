﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScript : MonoBehaviour
{
    public void LevelOne(){
        SceneManager.LoadScene("Gameplay");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
