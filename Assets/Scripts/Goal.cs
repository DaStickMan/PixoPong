using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if(isPlayerGoal)
            {
                Debug.Log("Player 2 Scored");
                GameObject.Find("_GM").GetComponent<GameManager>().Player2Scored();
            }
            else
            {
                Debug.Log("Player 1 Scored");
                GameObject.Find("_GM").GetComponent<GameManager>().Player1Scored();
            }
        }
    }
}
