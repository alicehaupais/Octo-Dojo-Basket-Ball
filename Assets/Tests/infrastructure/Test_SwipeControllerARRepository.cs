using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class Test_SwipeControllerARRepository
{
    private SwipeController _swipeController;

    private SwipeControllerARRepository swipeControllerARRepository;

    private void SetUp()
    {
        swipeControllerARRepository = new SwipeControllerARRepository(_swipeController);
    }

    [Test]
    public void EnableSwipeControllerSetToTrue()
    {
        swipeControllerARRepository.enableSwipeController();
        Assert.isTrue(_swipeController.enabled);
    }
}
