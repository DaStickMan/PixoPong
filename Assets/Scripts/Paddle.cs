using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1 = false;
    public int speed = 9;
    public GameObject ball = null;
    public int followDistance = 3;

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

    void Update()
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

    private void StoreBallPositionByDefinedDistance()
    {
        storedBallPositions.Add(ball.transform.position);

        if (storedBallPositions.Count > followDistance)
        {
            var distance = storedBallPositions[0] - transform.position;
            movement = distance.y > 0 ? 1 : -1;
            storedBallPositions.RemoveAt(0);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
