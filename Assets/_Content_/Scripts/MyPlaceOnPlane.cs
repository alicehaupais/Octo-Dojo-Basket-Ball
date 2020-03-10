using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MyPlaceOnPlane : PlaceOnPlane
{
    private bool _touchDetectionIsActive;
    private MyPlaneDetectionController _myPlaneDetectionController;

    protected override void Awake()
    {
        base.Awake();

        this._touchDetectionIsActive = true;
        this._myPlaneDetectionController = GetComponent<MyPlaneDetectionController>();
    }

    protected override void Update()
    {
        if (!this._touchDetectionIsActive)
            return;

        base.Update();

        if (spawnedObject != null)
        {
            ToggleTouchTrackingAndPlaneDetectionAndPointCloud();
        }
    }

    public void ToggleTouchTrackingAndPlaneDetectionAndPointCloud()
    {
        this._touchDetectionIsActive = false;
        this._myPlaneDetectionController.TogglePlaneDetectionAndPointCloud();
    }
}
