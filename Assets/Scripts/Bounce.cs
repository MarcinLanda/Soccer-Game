using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float jumpForce = 10f;
    public float power = 10f;
    public GameObject ball;

    private Vector2 force;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
                ball.SetActive(false);
            
        }
    }

}
