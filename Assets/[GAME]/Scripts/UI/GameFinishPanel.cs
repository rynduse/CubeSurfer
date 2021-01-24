using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishPanel : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSceneLoad.AddListener(HidePanel);
        EventManager.OnLevelFinish.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSceneLoad.RemoveListener(HidePanel);
        EventManager.OnLevelFinish.RemoveListener(ShowPanel);
    }
}
