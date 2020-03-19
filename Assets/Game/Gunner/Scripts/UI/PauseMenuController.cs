﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public void OnPauseMenuResume_Click()
    {
        GameManager.Instance.GameStatus = true;
    }

    public void OnPauseMenuMainMenu_Click()
    {
        GameManager.Instance.QuitGame();
    }

    public void OnPauseMenuQuit_Click()
    {
        Application.Quit();
    }
}