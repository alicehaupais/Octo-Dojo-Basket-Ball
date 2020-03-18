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
        //// A Test behaves as an ordinary method
        //[Test]
        //public void NewTestScriptSimplePasses()
        //{
        //    // Use the Assert class to test conditions
        //}

        //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        //// `yield return null;` to skip a frame.
        //[UnityTest]
        //public IEnumerator NewTestScriptWithEnumeratorPasses()
        //{
        //    // Use the Assert class to test conditions.
        //    // Use yield to skip a frame.
        //    yield return null;
        //}


        [Test]
        public void Test_ScoreIsInitializedAtZero()
        {
            // given
            ScoreController scoreController = null;

            // when
            scoreController = new ScoreController();

            // then
            Assert.AreEqual(0, scoreController.Score);
        }

        [Test]
        public void Test_ScoreCannotBeInferiorToZero()
        {
            // given
            ScoreController scoreController = new ScoreController();

            // when
            scoreController.AddScore(-1);

            // then
            Assert.GreaterOrEqual(scoreController.Score, 0);
        }

        [Test]
        public void Test_ScoreTextIsInitializedAtZero()
        {
            // given
            GameObject gameObject = new GameObject();
            gameObject.AddComponent<Text>();
            ScoreController scoreController = gameObject.AddComponent<ScoreController>();
            scoreController.Awake();

            // when
            scoreController.Start();

            // then
            Assert.AreEqual("0", scoreController.GetScoreFromTextComponent());
        }
    }
}
