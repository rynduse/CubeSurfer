using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
        private void OnEnable()
        {
            if (Managers.Instance == null)
                return;
        EventManager.OnBoxCollected.AddListener(MovePlayer);
        EventManager.OnBoxDropped.AddListener( ()=> { StartCoroutine(MovePlayerDG()); });
    }

        private void OnDisable()
        {
            if (Managers.Instance == null)
                return;
        EventManager.OnBoxCollected.RemoveListener(MovePlayer);
        EventManager.OnBoxDropped.RemoveListener(() => { StartCoroutine(MovePlayerDG()); });
    }

    IEnumerator MovePlayerDG()
    {
        yield return new WaitForSeconds(0.2f);
        transform.DOMoveY(0.5f * BoxManager.Instance.boxList.Count - 0.3f, 0.5f);
    }

    private void MovePlayer()
    {
        transform.position = new Vector3(transform.position.x, 0.5f * BoxManager.Instance.boxList.Count - 0.3f, transform.position.z);
    }
}
