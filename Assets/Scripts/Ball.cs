using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    public float force;
    public float waittime;
    public float timeLimit;
    private float timeLeft;

    private Vector3 ballPosition;
    private Vector3 ballScreen;
    private Vector3 mouseStart;

    private bool topTag;
    private bool bottomTag;
    private bool firstShot;
    private bool shooting;


    public Text scoreDisplay;
    public Text timer;

    private int score;
    private int shotCount;
    private int count;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        topTag = false;
        bottomTag = false;
        firstShot = false;

        score = 0;
        shotCount = 0;
        timeLimit = 90;
        count = 3;

        scoreDisplay.text = "Score: " + score.ToString();
        timer.text = "Time Left: " + FormatTime(timeLimit);
    }

    // Update is called once per frame
    void Update()
    {
        //Ball's current position
        ballPosition = transform.position;

        //Respawn ball if it goes off screen
        if (ballPosition.y < -5 || ballPosition.x > 9 || ballPosition.x < -9)
        {
            Respawn();
        }

        UpdateTimer();
    }
    private void FixedUpdate()
    {
        if (!shooting)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //Stores position of the ball in reference to the screen
        if (Input.GetMouseButtonDown(0) == true)
        {
            ballScreen = Camera.main.WorldToScreenPoint(ballPosition);
        }

        //Checks if mouse button was released
        if (Input.GetMouseButtonUp(0) == true)
        {
            //Finds the slope in which the ball should launch in vector form
            Vector3 direction = ballScreen - Input.mousePosition;
            float distance = Vector3.Distance(ballScreen, Input.mousePosition);

            direction.z = 0;
            rb.AddForce(direction * force);
            rb.angularVelocity = distance * force;
            rb.gravityScale = 1;

            firstShot = true;
            shooting = true;

            shotCount++;
            setCount(count-1);
        }
    }

    private void Respawn()
    {
        float randomx = Random.Range(-6, 2);
        float randomy = Random.Range(-4, 4);
        Vector3 randomLocation = new Vector3(randomx, randomy, 0);

        //Stops the ball's velocity
        rb.velocity = new Vector2(0, 0);
        //Stop ball from rotating
        rb.angularVelocity = 0;
        //Set rotation to 0,0,0
        gameObject.transform.rotation = Quaternion.identity;
        //Removes gravity from the ball
        rb.gravityScale = 0;
        gameObject.transform.position = randomLocation;

        topTag = false;
        bottomTag = false;
        shooting = false;
    }

    public void Score()
    {
        if (topTag == true && bottomTag == true)
        {
            StartCoroutine(WaitScore());
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        scoreDisplay.text = "Score: " + score.ToString();
    }

    IEnumerator WaitScore()
    {
        score++;
        yield return new WaitForSeconds(waittime);
        Respawn();
    }

    public void SetTopTag(bool ans)
    {
        topTag = ans;
    }

    public void SetBottomTag(bool ans)
    {
        bottomTag = ans;
    }

    public Vector3 GetBallPosition()
    {
        return ballPosition;
    }

    public int GetShotCount()
    {
        return shotCount;
    }

    string FormatTime(float time)
    {
        int intTime = (int)time;
        int mins = intTime / 60;
        int secs = intTime % 60;

        string timeText = string.Format("{0:00}:{1:00}", mins, secs);

        return timeText;
    }

    void UpdateTimer()
    {
        timeLeft = timeLimit - Time.time;

        //Start time after first shot
        if (firstShot == true)
        {
            timer.text = "Time Left: " + FormatTime(timeLeft);
        }

        //Destory the ball if the time limit is up
        if (timeLeft <= 0 && !shooting)
        {
            Destroy(gameObject);
        }
    }

    public void setCount(int num)
    {
            count = num;
    }

    public int getCount()
    {
        return count;
    }
}
