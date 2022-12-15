using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        CarrotManager.OnAllCarrotsCollected += GameWin;
        LoseGameOnCollision.OnGameLose += GameOver;
    }

    private void OnDisable()
    {
        CarrotManager.OnAllCarrotsCollected -= GameWin;
        LoseGameOnCollision.OnGameLose -= GameOver;
    }

    void GameOver() =>
        SceneManager.LoadScene("GameOverScene");

    void GameWin()
    {
        Debug.Log("All carrots collected");
    }
}