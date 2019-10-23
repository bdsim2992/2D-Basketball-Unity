using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topRim : MonoBehaviour
{
    Ball ballScript;
    // Start is called before the first frame update
    void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit 1");
        ballScript.SetTopTag(true);
    }
}
