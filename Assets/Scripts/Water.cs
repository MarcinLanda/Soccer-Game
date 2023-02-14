using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //public GameObject ball;
    public DragNShot dragNShot;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            dragNShot.yPow = .2f;
            dragNShot.xPow = .1f;
            dragNShot.power = 2f;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            dragNShot.yPow = 0;
            dragNShot.xPow = .05f;
            dragNShot.power = 4f;
        }
    }
}
