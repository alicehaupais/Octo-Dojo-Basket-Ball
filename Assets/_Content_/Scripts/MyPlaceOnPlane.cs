using UnityEngine.UI;

public class MyPlaceOnPlane : PlaceOnPlane
{
    public Button resetButton;
    public Text scoreText;

    private bool _touchDetectionIsActive;
    private MyPlaneDetectionController _myPlaneDetectionController;
    private MySwipeController _swipeController;

    protected override void Awake()
    {
        base.Awake();

        this._touchDetectionIsActive = true;
        this._myPlaneDetectionController = GetComponent<MyPlaneDetectionController>();
        this._swipeController = GetComponent<MySwipeController>();
    }

    protected override void Update()
    {
        if (!this._touchDetectionIsActive)
            return;

        base.Update();

        if (this.spawnedObject != null)
        {
            ToggleTouchTrackingAndPlaneDetectionAndPointCloud();
            this._swipeController.enabled = true;

            if (this.resetButton != null)
                this.resetButton.gameObject.SetActive(false);

            if (this.scoreText != null)
                this.scoreText.gameObject.SetActive(true);
        }
    }

    public void ToggleTouchTrackingAndPlaneDetectionAndPointCloud()
    {
        this._touchDetectionIsActive = false;
        this._myPlaneDetectionController.TogglePlaneDetectionAndPointCloud();
    }
}
