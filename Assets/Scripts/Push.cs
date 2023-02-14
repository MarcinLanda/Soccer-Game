using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour{
    public float xpower = 0f;
    public float ypower = 0f;
    public GameObject ball;

    private Vector2 force;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            force = new Vector2(xpower, ypower);
            ball.gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
    }
}
