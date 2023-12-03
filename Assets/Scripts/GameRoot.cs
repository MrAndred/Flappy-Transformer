using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private LoseScreen _loseScreen;

    private void OnEnable()
    {
        _bird.OnDied += OnBirdDied;
        _bird.OnScoreChanged += OnScoreChanged;

        _startScreen.PlayButtonClicked += OnStartButtonClick;
        _loseScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _bird.OnDied -= OnBirdDied;
        _bird.OnScoreChanged -= OnScoreChanged;

        _startScreen.PlayButtonClicked -= OnStartButtonClick;
        _loseScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Show();
        _loseScreen.Hide();
        _bird.ResetPlayer();
    }

    private void OnStartButtonClick()
    {
        Time.timeScale = 1;
        _startScreen.Hide();
        _bird.ResetPlayer();
        _enemySpawner.Init();
    }

    private void OnRestartButtonClick()
    {
        _loseScreen.Hide();
        _startScreen.Show();
        _bird.ResetPlayer();
        _enemySpawner.Init();
    }

    private void OnScoreChanged(int score)
    {
        Debug.Log($"Score: {score}");
    }

    private void OnBirdDied()
    {
        _loseScreen.Show();

        Time.timeScale = 0;
    }
}
