using System;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

public class MySwipeController : MonoBehaviour
{
    public ScreenTransformGesture screenTransfromGesture;
    public FlickGesture flickGesture;
    public GameObject basketBallPrefab;
    public Camera mainCamera;

    private GameObject basketBall;
    private Rigidbody basketBallRigidbody;
    private ScoringController basketBallScoringController;

    private void OnEnable()
    {
        this.screenTransfromGesture.TransformStarted += ShowBasketBall;
        this.screenTransfromGesture.Transformed += MoveBasketBall;
        this.flickGesture.Flicked += ThrowBasketBall;
    }

    private void OnDisable()
    {
        this.screenTransfromGesture.TransformStarted -= ShowBasketBall;
        this.screenTransfromGesture.Transformed -= MoveBasketBall;
        this.flickGesture.Flicked -= ThrowBasketBall;
    }

    private void ShowBasketBall(object sender, EventArgs e)
    {
        if (this.basketBall == null)
            this.basketBall = Instantiate(this.basketBallPrefab);

        if (this.basketBallRigidbody == null)
            this.basketBallRigidbody = this.basketBall.GetComponent<Rigidbody>();

        if (this.basketBallScoringController == null)
            this.basketBallScoringController = this.basketBall.GetComponent<ScoringController>();

        this.basketBallScoringController.ResetColliderNames();

        this.basketBallRigidbody.useGravity = false;
        this.basketBallRigidbody.velocity = Vector3.zero;
        this.basketBallRigidbody.rotation = Quaternion.identity;

        this.basketBall.transform.position = this.mainCamera.ScreenToWorldPoint(new Vector3(this.screenTransfromGesture.ScreenPosition.x, this.screenTransfromGesture.ScreenPosition.y, 0.1f));
    }

    private void MoveBasketBall(object sender, EventArgs e)
    {
        Vector2 screenPosition = this.screenTransfromGesture.ScreenPosition;

        this.basketBall.transform.position = this.mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 0.1f));
    }

    private void ThrowBasketBall(object sender, EventArgs e)
    {
        Vector3 direction3D = new Vector3(this.flickGesture.ScreenFlickVector.x, this.flickGesture.ScreenFlickVector.y, 0f);
        direction3D = direction3D.normalized;
        direction3D += this.mainCamera.transform.forward;
        direction3D *= 20f;

        this.basketBallRigidbody.useGravity = true;
        this.basketBallRigidbody.AddForce(direction3D / this.flickGesture.ScreenFlickTime);
    }
}


