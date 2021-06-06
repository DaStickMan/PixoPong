using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PaddleMovementationTest
    {
        [UnityTest]
        public IEnumerator MoveUp()
        {
            var gameObject = new GameObject();
            var rb = gameObject.AddComponent<Rigidbody2D>();
            var paddle = gameObject.AddComponent<Paddle>();

            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.gravityScale = 0;


            paddle.isPlayer1 = true;
            paddle.speed = 9;
            paddle.movement = 2;

            yield return new WaitForSeconds(1f);
            Assert.AreEqual(18, Mathf.Round(paddle.transform.position.y));
        }

        [UnityTest]
        public IEnumerator ResetPaddle()
        {
            var gameObject = new GameObject();
            var rb = gameObject.AddComponent<Rigidbody2D>();
            var paddle = gameObject.AddComponent<Paddle>();

            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.gravityScale = 0;

            paddle.isPlayer1 = true;
            paddle.speed = 9;
            paddle.movement = 2;

            yield return new WaitForSeconds(1f);

            paddle.Reset();

            Assert.AreEqual(Vector3.zero, paddle.transform.position);
            Assert.AreEqual(Vector2.zero, rb.velocity);
        }

        [UnityTest]
        public IEnumerator BotMovimentationTest()
        {
            var gameObject = new GameObject();
            var rb = gameObject.AddComponent<Rigidbody2D>();
            var paddle = gameObject.AddComponent<Paddle>();

            var ball = new GameObject();
            ball.gameObject.AddComponent<Ball>();

            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.gravityScale = 0;

            paddle.isPlayer1 = false;
            paddle.speed = 9;
            paddle.movement = 2;
            paddle.ball = ball;

            

            ball.transform.position = new Vector3(0, 3, 0);
            yield return new WaitForSeconds(1f);
            Assert.AreEqual(3, Mathf.Round(paddle.transform.position.y));            

            ball.transform.position = new Vector3(0, 1, 0);
            yield return new WaitForSeconds(1f);
            Assert.AreEqual(1, Mathf.Round(paddle.transform.position.y));

            ball.transform.position = new Vector3(0, -2, 0);
            yield return new WaitForSeconds(1f);
            Assert.AreEqual( -2, Mathf.Round(paddle.transform.position.y));
        }
    }
}
