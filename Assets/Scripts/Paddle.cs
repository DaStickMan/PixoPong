using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;
    public Rigidbody2D ball;

    private float movement;
    private Vector2 startPosition;

    private void Start()
    {
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
            var distance = ball.transform.position - transform.position;
            movement = distance.y > 0 ? 1 : -1;
        }


        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    internal void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
