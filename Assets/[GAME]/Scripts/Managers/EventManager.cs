using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnGameEnd = new UnityEvent();
    public static UnityEvent OnGameRestart = new UnityEvent();
    public static UnityEvent OnSceneLoad = new UnityEvent();

    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();

    public static UnityEvent OnLevelSuccess = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();

    public static UnityEvent OnSwipeDetected = new UnityEvent();
    public static UnityEvent OnTapDetected = new UnityEvent();
    public static UnityEvent OnSwipeFail = new UnityEvent();

    public static UnityEvent OnObstacleCreated = new UnityEvent();

    public static UnityEvent OnPlayerStartedRunning = new UnityEvent();

    //public static SwipeShowEvent OnSwipeNeeded = new SwipeShowEvent();
    public static UnityEvent OnSwipeCompleted = new UnityEvent();
    public static UnityEvent OnWrongSwipe = new UnityEvent();
    public static UnityEvent OnRightSwipe = new UnityEvent();

}
public class InputEvent : UnityEvent<UserInput, bool> { }