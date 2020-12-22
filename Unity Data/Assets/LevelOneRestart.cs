using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelOneRestart : MonoBehaviour{

    public void RestartMethod(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
