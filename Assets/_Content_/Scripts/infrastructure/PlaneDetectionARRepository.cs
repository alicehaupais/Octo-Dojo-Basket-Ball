using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDetectionARRepository : PlaneDetection, MonoBehaviour

{
    private MyPlaneDetectionController _myPlaneDetectionController;

    protected override void Awake()
    {
        base.Awake();
        this._myPlaneDetectionController = GetComponent<MyPlaneDetectionController>();
    }

    public void togglePlaneDetectionAndPointCloud()
    {
        _myPlaneDetectionController.TogglePlaneDetectionAndPointCloud();
    }

}
