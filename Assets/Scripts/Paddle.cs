using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public int speed;
    public GameObject ball;
    public int followDistance;

    public float movement;

    private Vector2 startPosition;
    private Rigidbody2D rb;

    private List<Vector3> storedBallPositions;

    private void Start()
    {
        storedBallPositions = new List<Vector3>();
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    { 
        if (isPlayer1 && movement != 2)
        {
            movement = Input.GetAxis("Vertical");

        }
        else if(!isPlayer1)
        {
            StoreBallPositionByDefinedDistance();            
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    private void  StoreBallPositionByDefinedDistance()
    {
        if (storedBallPositions.Count == 0)
        {
            storedBallPositions.Add(ball.transform.position); //store the players currect position
            return;
        }
        else if (storedBallPositions[storedBallPositions.Count - 1] != ball.transform.position)
        {
            storedBallPositions.Add(ball.transform.position); //store the position every frame
        }

        if (storedBallPositions.Count > followDistance)
        {
            var distance = storedBallPositions[0] - transform.position;      
            movement = distance.y > 1 ? 1 : distance.y;
            movement = distance.y < -1 ? -1 : distance.y;
            storedBallPositions.RemoveAt(0);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
