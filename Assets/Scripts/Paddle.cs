using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private bool isPlayer1;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject ball;
    [SerializeField] private int followDistance;

    private float movement;
    private Vector2 startPosition;

    private List<Vector3> storedBallPositions;

    private void Start()
    {
        storedBallPositions = new List<Vector3>();
        startPosition = transform.position;
    }

    void Update()
    {

        if (isPlayer1)
        {
            movement = Input.GetAxis("Vertical2");
        }
        else
        {
            storedBallPositions.Add(ball.transform.position);

            if(storedBallPositions.Count > followDistance)
            {
                var distance = storedBallPositions[0] - transform.position;
                movement = distance.y > 0 ? 1 : -1;
                storedBallPositions.RemoveAt(0);
            }
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    internal void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
