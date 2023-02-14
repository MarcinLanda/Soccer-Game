using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject addItems;
    private bool triggered = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (triggered)
            {
                addItems.SetActive(true);
                StartCoroutine(delete(1, false));
                triggered = false;
            }
        }
    }
    IEnumerator delete(int n, bool b)
    {
        yield return new WaitForSeconds(n);
        addItems.SetActive(b);
    }
}
