using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MyPlaceOnPlane : PlaceOnPlane
{
    private bool _touchDetectionIsActive;
    private MyPlaneDetectionController _myPlaneDetectionController;
    private SwipeController _swipeController;

    protected override void Awake()
    {
        base.Awake();

        this._touchDetectionIsActive = true;
        this._myPlaneDetectionController = GetComponent<MyPlaneDetectionController>();
        this._swipeController = GetComponent<SwipeController>();
    }

    protected override void Update()
    {
        if (!this._touchDetectionIsActive)
            return;

        base.Update();

        if (spawnedObject != null)
        {
            ToggleTouchTrackingAndPlaneDetectionAndPointCloud();
            this._swipeController.enabled = true;
        }
    }

    public void ToggleTouchTrackingAndPlaneDetectionAndPointCloud()
    {
        this._touchDetectionIsActive = false;
        this._myPlaneDetectionController.TogglePlaneDetectionAndPointCloud();
    }
}
