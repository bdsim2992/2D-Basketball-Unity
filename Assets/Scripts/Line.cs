using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update

    protected LineRenderer lr;
    Vector3 mouseStart;
    Vector3 currentMouse;
    protected Vector3 Direction;
    protected Vector3 Position;
    protected bool Pressed;
    Ball ball;
    private Color color;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        color = lr.material.color;
        //lr.sortingLayerName = "Foreground";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            mouseStart = ball.GetBallPosition();
            mouseStart.z = 0;
            lr.positionCount = 2;
            lr.SetPosition(0, mouseStart);
        }

        if(Input.GetMouseButton(0) == true)
        {
            currentMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Position = currentMouse;
            Position.z = 0;

            lr.SetPosition(1, Position);
        }

        if (Input.GetMouseButtonUp(0) == true)
        {
            lr.positionCount = 0;
        }
    }
}
