using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameManagerTest
    {
        [UnityTest]
        public IEnumerator GameManagerTestScore()
        {
            var gameObject = new GameObject();
            var gameManager = gameObject.AddComponent<GameManager>();

            var ball = new GameObject();
            var paddle1 = new GameObject();
            var paddle2 = new GameObject();
            var counterPanel = new GameObject();
            var menuPanel = new GameObject();
            var text = new GameObject();

            ball.AddComponent<Ball>();

            paddle2.AddComponent<Rigidbody2D>();
            paddle1.AddComponent<Rigidbody2D>();
            
            paddle1.AddComponent<Paddle>().isPlayer1 = true;
            paddle2.AddComponent<Paddle>().isPlayer1 = true;

            counterPanel.AddComponent<TextMeshProUGUI>();
            menuPanel.AddComponent<TextMeshProUGUI>();
            text.AddComponent<TextMeshProUGUI>();

            gameManager.waitSecondsStartGame = 3;
            gameManager.winnerPoints = 3;
            gameManager.ball = ball;
            gameManager.player1Paddle = paddle1;
            gameManager.player2Paddle = paddle2;
            gameManager.counterPanel = counterPanel;
            gameManager.menuPanel = menuPanel;
            gameManager.counterText = counterPanel.GetComponent<TextMeshProUGUI>();
            gameManager.player1Text = menuPanel.GetComponent<TextMeshProUGUI>();
            gameManager.player2Text = menuPanel.GetComponent<TextMeshProUGUI>();

            text.transform.SetParent(menuPanel.transform);

            yield return new WaitForSeconds(1);

            gameManager.Score(true);

            Assert.AreEqual("1", menuPanel.GetComponent<TextMeshProUGUI>().text);

            gameManager.Score(true);

            Assert.AreEqual("2", menuPanel.GetComponent<TextMeshProUGUI>().text);

            gameManager.Score(true);

            Assert.AreEqual("0", menuPanel.GetComponent<TextMeshProUGUI>().text);
            Assert.IsTrue(menuPanel.activeSelf);
            Assert.IsTrue(counterPanel.activeSelf);

            Debug.Log(menuPanel.activeSelf);
        }

        [UnityTest]
        public IEnumerator GameManagerTestStartGame()
        {
            var gameObject = new GameObject();
            var gameManager = gameObject.AddComponent<GameManager>();

            var ball = new GameObject();
            var paddle1 = new GameObject();
            var paddle2 = new GameObject();
            var counterPanel = new GameObject();
            var menuPanel = new GameObject();
            var text = new GameObject();

            ball.AddComponent<Ball>();

            paddle2.AddComponent<Rigidbody2D>();
            paddle1.AddComponent<Rigidbody2D>();

            paddle1.AddComponent<Paddle>().isPlayer1 = true;
            paddle2.AddComponent<Paddle>().isPlayer1 = true;

            counterPanel.AddComponent<TextMeshProUGUI>();
            menuPanel.AddComponent<TextMeshProUGUI>();
            text.AddComponent<TextMeshProUGUI>();

            gameManager.waitSecondsStartGame = 3;
            gameManager.winnerPoints = 3;
            gameManager.ball = ball;
            gameManager.player1Paddle = paddle1;
            gameManager.player2Paddle = paddle2;
            gameManager.counterPanel = counterPanel;
            gameManager.menuPanel = menuPanel;
            gameManager.counterText = counterPanel.GetComponent<TextMeshProUGUI>();
            gameManager.player1Text = menuPanel.GetComponent<TextMeshProUGUI>();
            gameManager.player2Text = menuPanel.GetComponent<TextMeshProUGUI>();

            text.transform.SetParent(menuPanel.transform);

            yield return null;

            gameManager.StartGame();

            Assert.AreEqual("3", counterPanel.GetComponent<TextMeshProUGUI>().text);

            yield return new WaitForSeconds(1f);

            Assert.AreEqual("2", counterPanel.GetComponent<TextMeshProUGUI>().text);

            yield return new WaitForSeconds(1f);

            Assert.AreEqual("1", counterPanel.GetComponent<TextMeshProUGUI>().text);

            yield return new WaitForSeconds(1f);

            Assert.AreEqual("GO", counterPanel.GetComponent<TextMeshProUGUI>().text);
            Assert.IsFalse(menuPanel.activeSelf);
            Assert.IsTrue(counterPanel.activeSelf);
        }
    }
}
