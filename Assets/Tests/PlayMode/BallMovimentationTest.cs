using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BallMovementationTest
    {
        [UnityTest]
        public IEnumerator LaunchBall()
        {
            var gameObject = new GameObject();
            var ball = gameObject.AddComponent<Ball>();
            
            ball.speed = 5;
            ball.Launch();

            yield return new WaitForSeconds(2f);
            Assert.AreEqual(10 , Mathf.Abs(Mathf.Round(ball.transform.position.x)));
            Assert.AreEqual(10 , Mathf.Abs(Mathf.Round(ball.transform.position.y)));            
        }

        [UnityTest]
        public IEnumerator ResetBall()
        {
            var gameObject = new GameObject();
            var ball = gameObject.AddComponent<Ball>();

            ball.speed = 5;
            ball.Reset();

            Assert.AreEqual(Vector3.zero, ball.transform.position);
            yield return null;
        }

        [UnityTest]
        public IEnumerator BallPositionFinishGame()
        {
            var gameObject = new GameObject();
            var ball = gameObject.AddComponent<Ball>();

            ball.speed = 5;
            ball.FinishGame();

            yield return new WaitForSeconds(2f);

            Assert.AreEqual(Vector3.zero, ball.transform.position);
        }
    }
}
