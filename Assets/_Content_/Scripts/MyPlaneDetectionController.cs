using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MyPlaneDetectionController : PlaneDetectionController
{
    private ARPointCloudManager _aRPointCloudManager;

    private void Start()
    {
        this._aRPointCloudManager = GetComponent<ARPointCloudManager>();
    }

    public void TogglePlaneDetectionAndPointCloud()
    {
        base.TogglePlaneDetection();

        var points = this._aRPointCloudManager.trackables;

        foreach (var pts in points)
        {
            pts.gameObject.SetActive(false);
        }

        this._aRPointCloudManager.enabled = false;
    }
}
