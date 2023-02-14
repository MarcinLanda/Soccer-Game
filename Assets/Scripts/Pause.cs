using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    public int level;
    public int mode;
    public GameObject popup;
    public GameObject ball;
    public GameObject removeButtons;
    public void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Destroy(ball);
            SceneManager.LoadScene(level, LoadSceneMode.Single);
            //button.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (popup.activeSelf) {
                popup.SetActive(false);
                removeButtons.SetActive(true);
            } else {
                popup.SetActive(true);
                removeButtons.SetActive(false);
            }
            
        }
    }
}
