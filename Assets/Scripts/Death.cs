using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour{
    public GameObject popup;
    public GameObject ball;
    public GameObject removeButtons;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            popup.SetActive(true);
            ball.SetActive(false);
            removeButtons.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody = collision.collider.GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                removeButtons.SetActive(false);
            }
        }
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
