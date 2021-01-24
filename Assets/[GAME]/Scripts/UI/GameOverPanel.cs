using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : Panel
{
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSceneLoad.AddListener(HidePanel);
        EventManager.OnLevelFail.AddListener(ShowPanel);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnSceneLoad.RemoveListener(HidePanel);
        EventManager.OnLevelFail.RemoveListener(ShowPanel);
    }
}
