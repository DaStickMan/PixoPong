using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int speed;

    private Vector3 velocity;

    private int directionX;
    private int directionY;
    
    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wall")
        {
            velocity.y *= -1;
        }
        else if(collision.tag == "Paddle")
        {
            velocity.x *= -1;
        }
    }

    void Launch()
    {
        velocity.x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        velocity.y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
    }

    private void Update()
    {
        transform.position += velocity * Time.deltaTime * speed;
    }

    public void Reset()
    {
        transform.position = Vector2.zero;
        Launch();
    }
}
