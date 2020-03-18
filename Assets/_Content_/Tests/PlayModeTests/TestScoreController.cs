using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TestScoreController
    {
        public GameObject scoreTextGameObject;
        public ScoreController scoreController;

        //// A Test behaves as an ordinary method
        //[Test]
        //public void TestScoreControllerSimplePasses()
        //{
        //    // Use the Assert class to test conditions
        //}

        //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        //// `yield return null;` to skip a frame.
        //[UnityTest]
        //public IEnumerator TestScoreControllerWithEnumeratorPasses()
        //{
        //    // Use the Assert class to test conditions.
        //    // Use yield to skip a frame.
        //    yield return null;
        //}

        [SetUp]
        public void SetUp()
        {
            scoreTextGameObject = new GameObject();
            scoreTextGameObject.AddComponent<Text>();
        }

        [UnityTest]
        public IEnumerator Test_ScoreTextIsUpdatedWhenScoreChange()
        {
            // given
            ScoreController scoreController = scoreTextGameObject.AddComponent<ScoreController>();
            yield return null;

            // when
            scoreController.AddScore(1);
            yield return null;

            // then
            Assert.AreEqual("1", scoreController.GetScoreFromTextComponent());
        }

        [TearDown]
        public void TearDown()
        {
            Object.Destroy(scoreTextGameObject);
        }
    }
}
