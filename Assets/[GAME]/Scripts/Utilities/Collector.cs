using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollactable collectable = other.GetComponent<ICollactable>();
        if (collectable == null)
            return;

        collectable.Collect();
    }
}
