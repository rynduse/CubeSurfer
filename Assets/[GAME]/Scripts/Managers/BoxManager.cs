using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : Singleton<BoxManager>
{
    public List<Box> boxList;
    private bool LevelFinish;
    public Text finishCoin;
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnBoxDropped.AddListener(LevelFailed);
        EventManager.OnCoinMultiplayer.AddListener(() => { StartCoroutine(Multiplayer()); });
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
        EventManager.OnBoxDropped.RemoveListener(LevelFailed);
        EventManager.OnCoinMultiplayer.RemoveListener(() => { StartCoroutine(Multiplayer()); });
    }

    public void LevelFailed()
    {
        if (boxList.Count < 1 && !LevelFinish)
        {
            GameManager.Instance.GameOver();
        }
    }

    IEnumerator Multiplayer()
    {
        LevelFinish = true;
        int lastBox;
        lastBox = boxList.Count;
        yield return new WaitForSeconds(0.1f);
        while (boxList.Count > 0)
        {
            boxList[0].FinishDropBox();
            yield return new WaitForSeconds(0.7f);
        }
        GameManager.Instance._coinAmount *= lastBox;
        finishCoin.text = GameManager.Instance._coinAmount.ToString();
        EventManager.OnLevelFinish.Invoke();
    }
}
