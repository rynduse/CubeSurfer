using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Box box = other.GetComponent<Box>();
        if (box == null)
            return;

        box.DropBox();
    }
}
