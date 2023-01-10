using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShot : MonoBehaviour
{
    public float power = 10f; //power of launch
    public Rigidbody2D rb; 

    public Vector2 minPower; //Set the minimum launch power
    public Vector2 maxPower; //Set the maximum launch power

    Trajectory trajectory;
    Camera cam;
    Vector2 force;
    Vector2 ballPos;
    Vector2 startPoint;
    Vector2 cp;

    private void Start()
    {
        cam = Camera.main;
        trajectory = GetComponent<Trajectory>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            ballPos = GameObject.Find("Ball").transform.position;
            if (Input.GetMouseButton(0))
            {
                Vector2 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                cp = ballPos + startPoint - currentPoint;
                Vector2 cpp = new Vector2(Mathf.Clamp(cp.x, ballPos.x - maxPower.x, ballPos.x + maxPower.x), Mathf.Clamp(cp.y, ballPos.y - maxPower.y, ballPos.y + maxPower.y));
                trajectory.RenderLine(ballPos, cpp);
            }

            if (Input.GetMouseButtonUp(0))
            {
                force = new Vector2(Mathf.Clamp((cp.x - ballPos.x), minPower.x, maxPower.x), Mathf.Clamp((cp.y - ballPos.y), minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
                trajectory.EndLine(); //Deletes the line from the screen
            }
        }
    } 
}
