using UnityEngine;
using System;
using System.Collections;
using System.Security.Permissions;
using System.Runtime.InteropServices;


public class DragNShot : MonoBehaviour
{
    public float power = 10f; //power of launch
    public float yPow;
    public float xPow = .05f;

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
    private Vector2 cpp;

    private void Update() {
        if (!paused.activeSelf || paused == null) {
            if (Input.GetMouseButtonDown(0)) {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            }
            //StartCoroutine(clock(1, true));
            if (Math.Abs(ball.gameObject.GetComponent<Rigidbody2D>().velocity.y) <= yPow && Math.Abs(ball.gameObject.GetComponent<Rigidbody2D>().velocity.x) <= xPow) {
                ballPos = ball.transform.position;
                if (Input.GetMouseButton(0)) {
                    holdingDown();
                }
                if (Input.GetMouseButtonUp(0)) {
                    letGo();
                }
            } else if (trajectory != null) {
                trajectory.EndLine();
            }
        }
    }
    void holdingDown(){
        Vector2 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        cp = ballPos + startPoint - currentPoint;
        float distance = Vector2.Distance(startPoint, currentPoint);
        float radius = 3.0f; 
        if (distance > radius) {
            cpp = ballPos + (startPoint - currentPoint).normalized * radius;
        } else {
            cpp = ballPos + (startPoint - currentPoint);
        }
        if (trajectory != null) {
            trajectory.RenderLine(ballPos, cpp);
        }
    }
    void letGo(){
        force = new Vector2(Mathf.Clamp((cp.x - ballPos.x), minPower.x, maxPower.x), Mathf.Clamp((cp.y - ballPos.y), minPower.y, maxPower.y));
        ball.gameObject.GetComponent<Rigidbody2D>().AddForce(force * power, ForceMode2D.Impulse);
        if (trajectory != null){
            trajectory.EndLine(); //Deletes the line from the screen
        }
    }
    IEnumerator clock(int n, bool b) {
        yield return new WaitForSeconds(n);
        Debug.Log(xPow + ", " + yPow);
    }
}
