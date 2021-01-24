using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour, ICharacterController
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _isSurfing;
    public float minX;
    public float maxX;
    public float currentX;
    public bool IsSurfing { get { return _isSurfing; } set { _isSurfing = value; } }
    public bool IsMoving { get { return _isSurfing; } set { _isSurfing = value; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.AddListener(CharacterStart);
        EventManager.OnLevelFail.AddListener(Stay);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameStart.RemoveListener(CharacterStart);
        EventManager.OnLevelFail.RemoveListener(Stay);
    }

    private void Update()
    {
        if (!IsSurfing)
            return;
        Surf();
        if (IsMoving)
        Move();
    }

    public void Surf()
    {
        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
    }

    public void Move()
    {
        if (InputManager.Instance._currentInput != UserInput.Swipe)
            return;
        currentX = InputManager.Instance.DeltaMousePosition / 650f;
        //Vector3 movePosition =  new Vector3(-currentX,transform.position.y,transform.position.z);
        Vector3 movePosition = new Vector3(currentX, 0, 0);
        //Debug.Log("diff : " + InputManager.Instance.MoveDirection());
        transform.position -= movePosition;
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX,transform.position.y,transform.position.z);
        }
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
    }

    public void CharacterStart()
    {
        IsSurfing = true;
        IsMoving = true;
    }

    public void Stay()
    {
        IsSurfing = false;
        IsMoving = false;
    }
}