using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningHowToProgram : MonoBehaviour
{ 

    private float speed = 5; 
    private float _health = 100;

    private void Start(){
        print("print test");
        Debug.Log("Debug.Log");

        int a = 1;
        int b = 2;
        int c = Calculate(a, b);
        Debug.Log("A + B = " + c);
        StartCoroutine(Execute());
    }

    IEnumerator Execute(){
        yield return new WaitForSeconds(2f);
    }

    public int Calculate(int a, int b){
        return a + b;
    }
}
