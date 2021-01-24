using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UserInput
{
    None,
    Tap,
    Left,
    Right,
    Swipe,
};


public class InputManager : Singleton<InputManager>
{
    public UserInput _currentInput = UserInput.None;
    private float _deltaMousePosition;
    public float DeltaMousePosition { get { return _deltaMousePosition; } private set { _deltaMousePosition = value; } }

    [SerializeField] private float _swipeResist = 70f;
    private float _swipeAngle = 0f;
    private Vector2 _firstTouchPosition;
    private Vector2 _finalTouchPosition;
    private float _firstFinalDiff;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
    }

    private void Update()
    {
        GetMouseInput();
    }

    //private void SwipeInput()
    //{
    //    if (GetMouseInput())
    //    {
    //        float touchDiff = Vector2.Distance(_finalTouchPosition, _firstTouchPosition);
    //        if (touchDiff >= _swipeResist)
    //            CalculateAngle();
    //        else
    //            EventManager.OnSwipeFail.Invoke();
    //    }
    //}

    //void CalculateAngle()
    //{
    //    _swipeAngle = Mathf.Atan2(_finalTouchPosition.y - _firstTouchPosition.y, _finalTouchPosition.x - _firstTouchPosition.x) * 180 / Mathf.PI;
    //    SwipeDir();
    //    EventManager.OnSwipeDetected.Invoke();
    //}

    //public float MoveDirection()
    //{
    //    _firstFinalDiff = _firstTouchPosition.x - _finalTouchPosition.x;
    //    return _firstFinalDiff;
    //}

    private void GetMouseInput()
    {
        _currentInput = UserInput.None;
        if (Input.GetMouseButton(0))
        {
            // Swipe/Click started
            if (Input.GetMouseButtonDown(0))
            {
                if (!GameManager.Instance.isGameStarted)
                {
                    EventManager.OnGameStart.Invoke();
                }
                //_firstFinalDiff = CharacterManager.Instance.Player.transform.position.x;
                _firstTouchPosition = (Vector2)Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                _finalTouchPosition = (Vector2)Input.mousePosition;
                //return true;
                // Swipe/Click finished
            }
            DeltaMousePosition = _firstTouchPosition.x - _finalTouchPosition.x;
            _firstTouchPosition = _finalTouchPosition;
            _currentInput = UserInput.Swipe;
            //else if(Input.GetMouseButtonUp(0))
            //{
            //    _finalTouchPosition = (Vector2)Input.mousePosition;
            //    EventManager.OnSwipeCompleted.Invoke();
            //    return true;
            //}
        }
        //return false;
    }

    private void SwipeDir()
    {
        if (_swipeAngle > -90 && _swipeAngle <= 90)
        {
            //Right Swipe
            _currentInput = UserInput.Right;
        }
        else if (_swipeAngle > 90 || _swipeAngle <= -90)
        {
            //Left Swipe
            _currentInput = UserInput.Left;
        }
    }
}