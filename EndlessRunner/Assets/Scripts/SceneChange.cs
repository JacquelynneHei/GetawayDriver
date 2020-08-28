﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Store()
    {

    }

    public void Home()
    {

    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
