using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Test_SpawnBasketBallNet
    {
        private bool firstTouchDetection;
        private PlaneDetectionRepository planeDetectionRepository;
        private SwipeControllerRepository swipeControllerRepository;

        private SpawnBasketBallNet spawnBasketBallNet;

        private void SetUp()
        {
            spawnBasketBallNet = new SpawnBasketBallNet(firstTouchDetection, planeDetectionRepository, swipeControllerRepository);
        }

        [Test]
        public void firstTouchDetectionSetToFalse()
        {
            spawnBasketBallNet.TogglePlaneDetectionAndEnableSwipeController();
            Assert.isfalse(firstTouchDetection);
        }

        [Test]
        public void verifyTogglePlaneDetectionWasCalled()
        {
            spawnBasketBallNet.TogglePlaneDetectionAndEnableSwipeController();
            Mock.Get(planeDetectionRepository).Verify(x =>
                x.togglePlaneDetectionAndPointCloud(), Times.Once);
        }

        [Test]
        public void verifyEnableSwipeWasCalled()
        {
            spawnBasketBallNet.TogglePlaneDetectionAndEnableSwipeController();
            Mock.Get(swipeControllerRepository).Verify(x =>
                x.enableSwipeController, Times.Once);
        }
    }
}
