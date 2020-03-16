using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControllerARRepository : SwipeControllerRepository, Monobehaviour
{
    private SwipeController _swipeController;

    protected override void Awake()
    {
        base.Awake();
        this._swipeController = GetComponent<SwipeController>();
    }

    public void enableSwipeController()
    {
        this._swipeController.enabled = true;
    }
}
