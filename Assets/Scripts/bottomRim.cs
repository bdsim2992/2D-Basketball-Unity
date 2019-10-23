using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomRim : MonoBehaviour
{
    Ball ballScript;
    // Start is called before the first frame update
    void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("hit 2");
        ballScript.SetBottomTag(true);
        ballScript.Score();
    }
}
