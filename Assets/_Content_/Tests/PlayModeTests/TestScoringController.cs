using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScoringController
    {
        //// A Test behaves as an ordinary method
        //[Test]
        //public void TestScoringControllerSimplePasses()
        //{
        //    // Use the Assert class to test conditions
        //}

        //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        //// `yield return null;` to skip a frame.
        //[UnityTest]
        //public IEnumerator TestScoringControllerWithEnumeratorPasses()
        //{
        //    // Use the Assert class to test conditions.
        //    // Use yield to skip a frame.
        //    yield return null;
        //}

        ///////////////////////////////////////////
        // TO STOP THE TEST AND LOOK INTO THE SCENE
        // THIS IS NASTY...
        ///////////////////////////////////////////
        //
        // yield return null;
        //
        //     try
        //     {
        //         Assert.Fail();
        //     }
        //     catch (AssertionException ex)
        //     {
        //         LogAssert.ignoreFailingMessages = true;
        //         Debug.LogException(ex);
        //         Debug.Break();
        //     }
        //
        // yield return null;
        //
        ///////////////////////////////////////////

        [UnityTest]
        public IEnumerator Test_WhenBasketBallTriggerOnlyBasketTopColliderCheckColliderNamesOrderIsFalse()
        {
            // given SetUp
            SceneManager.LoadScene("_Content_/Tests/TestScenes/BasketTopColliderTestScene");

            yield return null;

            GameObject basketBall = GameObject.Find("BasketBall");
            ScoringController scoringController = basketBall.GetComponent<ScoringController>();

            // when
            yield return new WaitUntil(() => basketBall.transform.position.y < -1f);

            // then
            Assert.IsFalse(scoringController.CheckColliderNamesOrder());
        }

        [UnityTest]
        public IEnumerator Test_WhenBasketBallTriggerOnlyBasketBottomColliderCheckColliderNamesOrderIsFalse()
        {
            // given SetUp
            SceneManager.LoadScene("_Content_/Tests/TestScenes/BasketBottomColliderTestScene");

            yield return null;

            GameObject basketBall = GameObject.Find("BasketBall");
            ScoringController scoringController = basketBall.GetComponent<ScoringController>();

            // when
            yield return new WaitUntil(() => basketBall.transform.position.y < -1f);

            // then
            Assert.IsFalse(scoringController.CheckColliderNamesOrder());
        }

        [UnityTest]
        public IEnumerator Test_WhenBasketBallTriggerBasketBottomThenTopCollidersScoreIsZero()
        {
            // given SetUp
            SceneManager.LoadScene("_Content_/Tests/TestScenes/BasketBottomToTopColliderTestScene");

            yield return null;

            GameObject basketBall = GameObject.Find("BasketBall");
            GameObject scoreText = GameObject.Find("Score Number Text");
            ScoreController scoreController = scoreText.GetComponent<ScoreController>();

            // when
            yield return new WaitUntil(() => basketBall.transform.position.y < -1f);

            // then
            Assert.AreEqual("0", scoreController.GetScoreFromTextComponent());
        }

        [UnityTest]
        public IEnumerator Test_WhenBasketBallTriggerBasketTopThenBottomCollidersScoreIsOne()
        {
            // given SetUp
            SceneManager.LoadScene("_Content_/Tests/TestScenes/BasketTopToBottomColliderTestScene");

            yield return null;

            GameObject basketBall = GameObject.Find("BasketBall");
            GameObject scoreText = GameObject.Find("Score Number Text");
            ScoreController scoreController = scoreText.GetComponent<ScoreController>();

            // when
            yield return new WaitUntil(() => basketBall.transform.position.y < -1f);

            // then
            Assert.AreEqual("1", scoreController.GetScoreFromTextComponent());
        }
    }
}
