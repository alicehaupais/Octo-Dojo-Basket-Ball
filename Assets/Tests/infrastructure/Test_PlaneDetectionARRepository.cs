using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_PlaneDetectionARRepository 
{

    private MyPlaneDetectionController _myPlaneDetectionController;

    private PlaneDetectionARRepository planeDetectionARRepository;

    private void SetUp()
    {
        planeDetectionARRepository = new PlaneDetectionARRepository(_myPlaneDetectionController);
    }

    [Test]
    public void verifyTogglePlaneDetectionWasCalled()
    {
        planeDetectionARRepository.togglePlaneDetectionAndPointCloud();
        Mock.Get(_myPlaneDetectionController).Verify(x =>
            x.TogglePlaneDetectionAndPointCloud(), Times.Once);
    }
}
