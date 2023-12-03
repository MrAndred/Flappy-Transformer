using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private BirdMover _birdMover;

    private int _score;

    public Action OnDied;
    public Action<int> OnScoreChanged;

    public void ResetPlayer()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
        _birdMover.ResetBird();
    }

    public void Die()
    {
        OnDied?.Invoke();
    }

    public void AddScore()
    {
        _score++;
        OnScoreChanged?.Invoke(_score);
    }

    public void OnEnemyDied(Enemy enemy)
    {
        AddScore();
        enemy.OnDied -= OnEnemyDied;
    }
}
