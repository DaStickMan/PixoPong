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
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public TextMeshProUGUI counterText;
    public GameObject counterPanel;
    public GameObject menuPanel;

    [Header("Game settings")]
    public int waitSecondsStartGame;
    public int winnerPoints;
    
    private int player1Score;
    private int player2Score;

    public void Score(bool isPlayerGoal)
    {
        if (isPlayerGoal)
        {
            player1Score++;
            player1Text.text = player1Score.ToString();            
        }
        else
        {
            player2Score++;
            player2Text.text = player2Score.ToString();
        }

        FinishGameOrContinue();        
    }

    private void FinishGameOrContinue()
    {
        if (player2Score == winnerPoints || player1Score == winnerPoints)
        {
            PrepareSceneToPlayAgain();
        }
        else
        {
            ResetPostion();
        }
    }

    private void PrepareSceneToPlayAgain()
    {
        string playerWins = player1Score > player2Score ? "Player 2 Wins!" : "Player 1 Wins!";

        menuPanel.GetComponentsInChildren<TextMeshProUGUI>()[0].text = playerWins;
        menuPanel.GetComponentsInChildren<TextMeshProUGUI>()[1].text = "Play again";

        player1Score = 0;
        player2Score = 0;

        player1Text.text = player1Score.ToString();
        player2Text.text = player2Score.ToString();        

        ball.GetComponent<Ball>().FinishGame();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();

        menuPanel.SetActive(true);
        counterPanel.SetActive(true);
    }

    private void ResetPostion()
    {
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }

    private IEnumerator CountSecondsToStart()
    {
        for (int i = waitSecondsStartGame; i >= 0; i--)
        {
            if(i == 0)
            {
                counterText.text = "GO";
            }
            else
            {
                counterText.text = i.ToString();
            }

            yield return new WaitForSeconds(1f);            
        }

        counterPanel.SetActive(false);
        ball.GetComponent<Ball>().Launch();
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        StartCoroutine(CountSecondsToStart());
    }
}
