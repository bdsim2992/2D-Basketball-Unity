using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    Ball ball;

    private float randomX;
    private float randomY;
    private float t;

    private Vector3 startPosition;
    private Vector3 randomLocation;

    private bool move;
    private bool nextShot;

    private float counter;
    private float currentShot;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();

        randomX = Random.Range(6, 10);
        randomY = Random.Range(1f, 8.3f);
        startPosition = gameObject.transform.position;
        randomLocation = new Vector3(randomX, randomY, 0);
        t = 0;
        counter = 3;
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveHoop(startPosition, randomLocation, 5));
        print(move);

        if (gameObject.transform.position == randomLocation)
        {
            SetMove(false);
            //startPosition = end;
            //randomX = Random.Range(6, 10);
            //randomY = Random.Range(1f, 8.3f);
            //randomLocation = new Vector3(randomX, randomY, 0);
            //counter = 3;
        }
        print(move);
    }



    IEnumerator MoveHoop(Vector3 start, Vector3 end, float time)
    {
        if (ball.GetShotCount() >= 1 && (counter - ball.GetShotCount()) == 0)
        {
            SetMove(true);
        }

        if (move)
        {
            t += Time.deltaTime / 5;
            gameObject.transform.position = Vector3.Lerp(start, end, t);
        }

        yield return null;
    }



    private void SetMove(bool ans)
    {
        move = ans;
    }
}
