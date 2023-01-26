using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSwitch : MonoBehaviour{
    // Start is called before the first frame update
    public GameObject txt;
    public GameObject bubl;

    void Start(){
        StartCoroutine(text(2, true));
        StartCoroutine(textBubble(10, false));
    }

    IEnumerator text(int n, bool b){
        yield return new WaitForSeconds(n);
        txt.SetActive(b);
    }

    IEnumerator textBubble(int n, bool b){
        yield return new WaitForSeconds(n);
        txt.SetActive(b);
        bubl.SetActive(b);
    }
}
