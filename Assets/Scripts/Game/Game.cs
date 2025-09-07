using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _palyer;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyBulletSpawner _enemyBulletSpawner;
    [SerializeField] private PlayerBulletSpawner _playerBulletSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.RestartButtonClicked += OnRestartButtonClick;
        _palyer.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.RestartButtonClicked -= OnRestartButtonClick;
        _palyer.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endScreen.Close();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _palyer.Reset();
        _enemySpawner.Reset();
        _enemyBulletSpawner.Reset();
        _playerBulletSpawner.Reset();
    }
}