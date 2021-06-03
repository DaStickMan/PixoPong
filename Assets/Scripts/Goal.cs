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
            GameObject.Find("_GM").GetComponent<GameManager>().Score(isPlayerGoal);
        }
    }
}
