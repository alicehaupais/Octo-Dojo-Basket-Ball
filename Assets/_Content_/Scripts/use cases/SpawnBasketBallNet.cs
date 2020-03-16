using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnBasketBallNet : PlaceOnPlane
{
    private bool firstTouchDetection;
    private PlaneDetectionRepository planeDetectionRepository;
    private SwipeControllerRepository swipeControllerRepository;

    protected override void Awake()
    {
        base.Awake();

        this.firstTouchDetection = true;
        this.planeDetectionRepository = new PlaneDetectionARRepository();
        this.swipeControllerRepository = new SwipeControllerARRepository();
        this._swipeController = GetComponent<SwipeController>();
    }

    protected override void Update()
    {
        if (!this.firstTouchDetection)
            return;

        base.Update();

        if (spawnedObject != null)
        {
            TogglePlaneDetectionAndEnableSwipe();
        }
    }


    public void TogglePlaneDetectionAndEnableSwipe()
    {
        this.firstTouchDetection = false;
        this.planeDetectionRepository.togglePlaneDetectionAndPointCloud();
        this.swipeControllerRepository.enableSwipeController();
    }
}
