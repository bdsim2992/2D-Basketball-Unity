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
        counter = ball.getCount();
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        counter = ball.getCount();
        if ((counter <= 0)){
            StartCoroutine(MoveHoop(startPosition, randomLocation, 5));
        }
        if (gameObject.transform.position == randomLocation)
        {
            StopCoroutine(MoveHoop(startPosition, randomLocation, 5));
            //Set counter till hoop moves to a random number
            ball.setCount(Random.Range(2, 5));
            //Set t to zero so the hoop doesn't teleport
            t = 0;
            //Update and set new random hoop positions
            setHoopPositions();
        }
        counter = ball.getCount();
    }



    IEnumerator MoveHoop(Vector3 start, Vector3 end, float time)
    {
        t += Time.deltaTime / time;
        //Move hoop to end postiton within the time variable
        gameObject.transform.position = Vector3.Lerp(start, end, t);
        yield return null;
    }


    private void setHoopPositions()
    {
        startPosition = randomLocation;
        randomX = Random.Range(6, 10);
        randomY = Random.Range(1f, 8.3f);
        randomLocation = new Vector3(randomX, randomY, 0);
    }
    private void SetMove(bool ans)
    {
        move = ans;
    }

    private void minusCount()
    {
        counter -= 1;
    }
}
