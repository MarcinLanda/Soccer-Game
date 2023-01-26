using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour{
    public GameObject popup;
    public GameObject ball;
    public GameObject removeButtons;

    void OnTriggerEnter2D(){
        popup.SetActive(true);
        ball.SetActive(false);
        removeButtons.SetActive(false);
    }

    public void Pause(){
        popup.SetActive(true);
        removeButtons.SetActive(false);
    }

    public void Unpause(){
        popup.SetActive(true);
        removeButtons.SetActive(false);
    }
}
