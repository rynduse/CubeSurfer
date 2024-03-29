﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    public bool isGameStarted;
    public int _coinAmount = 0;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameRestart.AddListener(GameRestart);
        EventManager.OnGameStart.AddListener(StartGame);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnGameRestart.RemoveListener(GameRestart);
        EventManager.OnGameStart.RemoveListener(StartGame);
    }

    public void StartGame()
    {
        if (isGameStarted)
            return;
        EventManager.OnLevelStart.Invoke();
        isGameStarted = true;
    }

    public void GameOver()
    {
        if (!isGameStarted)
            return;
        isGameStarted = false;
        EventManager.OnLevelFail.Invoke();
    }

    //public void GameEnd(Character champion)
    //{
    //    foreach (var character in CharacterManager.Instance.Characters)
    //        character.Won = false;
    //    champion.Won = true;

    //    EventManager.OnLevelFinish.Invoke();
    //    isGameStarted = false;
    //}

    private void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}