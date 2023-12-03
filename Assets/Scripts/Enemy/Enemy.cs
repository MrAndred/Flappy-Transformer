using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyShooter _shooter;

    private bool _isInitialized;
    public Action<Enemy> OnDied;

    public void Init()
    {
        _isInitialized = true;
        _shooter.Init();
    }

    public void Die()
    {
        OnDied?.Invoke(this);

        _isInitialized = false;
        _shooter.StopShooting();
        gameObject.SetActive(false);
    }
}
