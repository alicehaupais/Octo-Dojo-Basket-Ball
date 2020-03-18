using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringController : MonoBehaviour, IScoringController
{
    private List<string> colliderNames;
    private ScoreController scoreController;

    public ScoringController()
    {
        colliderNames = new List<string>();
    }

    public void Start()
    {
        scoreController = GameObject.Find("Score Text").GetComponent<ScoreController>();
    }

    public void Update()
    {
        if (CheckColliderNamesOrder())
        {
            AddScore();
            ResetColliderNames();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        AddColliderName(other.name);
    }

    public void AddColliderName(string colliderName)
    {
        colliderNames.Add(colliderName);
    }

    public bool CheckColliderNamesOrder()
    {
        if (colliderNames.Count == 2) return IsFirstColliderBasketTopCollider() && IsSecondColliderBasketBottomCollider();
        else return false;
    }

    public bool IsFirstColliderBasketTopCollider()
    {
        return colliderNames[0] == "TopCollider";
    }

    public bool IsSecondColliderBasketBottomCollider()
    {
        return colliderNames[1] == "BottomCollider";
    }

    public void AddScore()
    {
        scoreController.AddScore(1);
    }

    public void ResetColliderNames()
    {
        colliderNames.RemoveAll((name) => true);
    }
}
