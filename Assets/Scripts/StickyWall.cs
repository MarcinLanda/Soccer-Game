using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyWall : MonoBehaviour
{
    public GameObject ball;

    private float threshold = .000000000001f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody = collision.collider.GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0;
            rigidbody.gravityScale = 0;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rb = ball.gameObject.GetComponent<Rigidbody2D>();
        if (rb.velocity.magnitude > threshold)
        {
            rb.gravityScale = 1.5f;
        }
    }

}
