using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{

    private Rigidbody rigidbody;
    public Rigidbody Rigidbody { get { return (rigidbody == null) ? rigidbody = GetComponent<Rigidbody>() : rigidbody; } }

    private Collider collider;
    public Collider Collider { get { return (collider == null) ? collider = GetComponent<Collider>() : collider; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        CharacterManager.Instance.AddCharacter(this);
        EventManager.OnLevelFinish.AddListener(() => StopAllCoroutines());
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        CharacterManager.Instance.RemoveCharacter(this);
        EventManager.OnLevelFinish.RemoveListener(() => StopAllCoroutines());
    }
}