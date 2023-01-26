using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShot : MonoBehaviour
{
    public float power = 10f; //power of launch

    public GameObject ball;
    public GameObject paused;

    public Vector2 minPower; //Set the minimum launch power
    public Vector2 maxPower; //Set the maximum launch power

    public Trajectory trajectory;

    public Camera cam;

    private Vector2 force;
    private Vector2 ballPos;
    private Vector2 startPoint;
    private Vector2 cp;

    private void Update(){
        if (!paused.activeSelf || paused == null){
            if (Input.GetMouseButtonDown(0)){
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (ball.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude == 0){
                ballPos = ball.transform.position;

                if (Input.GetMouseButton(0)){
                    Vector2 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                    cp = ballPos + startPoint - currentPoint;
                    Vector2 cpp = new Vector2(Mathf.Clamp(cp.x, ballPos.x - maxPower.x, ballPos.x + maxPower.x), Mathf.Clamp(cp.y, ballPos.y - maxPower.y, ballPos.y + maxPower.y));
                    if (trajectory != null){
                        trajectory.RenderLine(ballPos, cpp);
                    }
                }

                if (Input.GetMouseButtonUp(0)){
                    force = new Vector2(Mathf.Clamp((cp.x - ballPos.x), minPower.x, maxPower.x), Mathf.Clamp((cp.y - ballPos.y), minPower.y, maxPower.y));
                    ball.gameObject.GetComponent<Rigidbody2D>().AddForce(force * power, ForceMode2D.Impulse);
                    if (trajectory != null){
                        trajectory.EndLine(); //Deletes the line from the screen
                    }
                }
            }
        }
    } 
}
