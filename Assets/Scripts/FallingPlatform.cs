using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float crumbleTime = 1f;
    public Collider2D collider;
    public Rigidbody2D rigidbody;
    public float height = -3f;

    private float crumbleTimer = 0f;
    private bool crumbling = false;
    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            crumbling = true;
        }
    }

    void Update()
    {
        if (crumbling)
        {
            crumbleTimer += Time.deltaTime;
            if (crumbleTimer >= crumbleTime)
            {
                collider.enabled = false;
                rigidbody.isKinematic = false;
            }
        }

        if (!collider.enabled && transform.position.y < height)
        {
            Destroy(gameObject);
        }
    }
}

