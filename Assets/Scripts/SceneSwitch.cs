using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour{
    public int level;
    public int mode;
    public GameObject restart;
    public GameObject button;
    public GameObject bubl;

    void OnTriggerEnter2D(){
        if (mode == 1){
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        } else {
            SceneManager.LoadScene(level, LoadSceneMode.Additive);
        }
    }

    public void NewGameButton(){
        GameObject ball = GameObject.Find("Ball");
        if (mode == 1){
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        } else {
            if (button.name == "Start"){
                button.SetActive(false);
                restart.SetActive(true);
                bubl.SetActive(true);
                SceneManager.LoadScene(level, LoadSceneMode.Additive);
            } else if (button.name == "Retry"){
                Rigidbody2D rb;
                Destroy(ball);
                SceneManager.LoadScene(level, LoadSceneMode.Additive);
                button.SetActive(true);
            }
        }
    }
}
