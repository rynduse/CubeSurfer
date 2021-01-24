using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Box : MonoBehaviour, ICollactable
{
    private Transform player;
    private Rigidbody rb;
    public AudioSource audioSource;
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnBoxCollected.AddListener(MoveBox);
        EventManager.OnBoxDropped.AddListener(() => { StartCoroutine(MoveBoxDG()); });
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnBoxCollected.RemoveListener(MoveBox);
        EventManager.OnBoxDropped.RemoveListener(() => { StartCoroutine(MoveBoxDG()); });
    }

    void Start()
    {
        player = CharacterManager.Instance.Player.transform;
        rb = GetComponent<Rigidbody>();
    }

    public void Collect()
    {
        BoxManager.Instance.boxList.Add(this);
        EventManager.OnBoxCollected.Invoke();
        transform.parent = player;
        audioSource.Play();
    }

    public void DropBox()
    {
        if (BoxManager.Instance.boxList.Contains(this))
        {
            GetComponent<BoxCollider>().isTrigger = false;
            transform.parent = null;
            BoxManager.Instance.boxList.Remove(this);
            rb.isKinematic = false;
            rb.useGravity = true;
            EventManager.OnBoxDropped.Invoke();
        }
    }

    public void FinishDropBox()
    {
        if (BoxManager.Instance.boxList.Contains(this))
        {
            transform.parent = null;
            BoxManager.Instance.boxList.Remove(this);
            Destroy(this);
            EventManager.OnBoxDropped.Invoke();
        }
    }

    IEnumerator MoveBoxDG()
    {
        if (BoxManager.Instance.boxList.Contains(this))
        {
            yield return new WaitForSeconds(0.2f);
            transform.DOMoveY(BoxManager.Instance.boxList.IndexOf(this) * 0.5f, 0.5f);
        }
    }

    public void MoveBox()
    {
        if (BoxManager.Instance.boxList.Contains(this))
        {
            transform.position = new Vector3(player.position.x, 0.5f * BoxManager.Instance.boxList.IndexOf(this), player.position.z);
        }
    }
}
