using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("UI")]
    public TextMeshProUGUI Player1Text;
    public TextMeshProUGUI Player2Text;
    public TextMeshProUGUI CounterText;
    public GameObject CounterPanel;
    public GameObject MenuPanel;

    [Header("Game settings")]
    public int WaitSecondsStartGame;
    public int winnerPoints;
    
    private int Player1Score;
    private int Player2Score;

    internal void Score(bool isPlayerGoal)
    {
        if (isPlayerGoal)
        {
            Player1Score++;
            Player1Text.text = Player1Score.ToString();            
        }
        else
        {
            Player2Score++;
            Player2Text.text = Player2Score.ToString();
        }

        if(Player2Score == winnerPoints || Player1Score == winnerPoints)
        {
            string playerWins = Player1Score > Player2Score ? "Player 2 Wins!" : "Player 1 Wins!";

            MenuPanel.GetComponentsInChildren<TextMeshProUGUI>()[0].text = playerWins;
            MenuPanel.GetComponentsInChildren<TextMeshProUGUI>()[1].text = "Play again";

            ResetScene();
        }
        else
        {
            ResetPostion();
        }
    }

    private void ResetScene()
    {
        Player1Score = 0;
        Player2Score = 0;

        Player1Text.text = Player1Score.ToString();
        Player2Text.text = Player2Score.ToString();        

        ball.GetComponent<Ball>().FinishGame();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();

        MenuPanel.SetActive(true);
        CounterPanel.SetActive(true);
    }

    private void ResetPostion()
    {
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }

    private IEnumerator CountSeconds()
    {
        for (int i = WaitSecondsStartGame; i >= 0; i--)
        {
            if(i == 0)
            {
                CounterText.text = "GO";
            }
            else
            {
                CounterText.text = i.ToString();
            }

            yield return new WaitForSeconds(1f);            
        }

        

        CounterPanel.SetActive(false);
        ball.GetComponent<Ball>().Launch();
    }

    public void StartGame()
    {
        MenuPanel.SetActive(false);
        StartCoroutine(CountSeconds());
    }
}
