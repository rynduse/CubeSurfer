using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : Singleton<BoxManager>
{
    public List<Box> boxList;
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
}
