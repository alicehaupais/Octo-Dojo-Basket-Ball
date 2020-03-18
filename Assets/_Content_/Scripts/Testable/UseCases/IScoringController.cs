using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoringController
{
    void AddColliderName(string colliderName);

    bool CheckColliderNamesOrder();

    bool IsFirstColliderBasketTopCollider();

    bool IsSecondColliderBasketBottomCollider();

    void AddScore();

    void ResetColliderNames();
}
