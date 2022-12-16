using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Game manager is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public List<GameObject> enemies = new();

    private void OnEnable()
    {
        CarrotManager.OnAllCarrotsCollected += GameWin;
        PlayerNavMeshController.OnGameLose += GameOver;
    }

    private void OnDisable()
    {
        CarrotManager.OnAllCarrotsCollected -= GameWin;
        PlayerNavMeshController.OnGameLose -= GameOver;
    }

    void GameOver() =>
        SceneManager.LoadScene("GameOverScene");

    void GameWin() =>
        SceneManager.LoadScene("GameWinScene");
}