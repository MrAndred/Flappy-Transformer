using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private Bird _bird;

    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    private bool _isInitialized = false;
    private Coroutine _spawning;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if (_spawning != null)
        {
            StopCoroutine(_spawning);
        }

        _isInitialized = true;
        _enemyPool.ResetEnemies();
        _spawning = StartCoroutine(SpawnByPeriod());
    }

    private IEnumerator SpawnByPeriod()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnDelay);

        while (_isInitialized == true)
        {
            yield return waitForSeconds;

            if (_enemyPool.TryGetEnemy(out Enemy enemy) == true)
            {
                enemy.transform.position = new Vector2(transform.position.x, Random.Range(_minPositionY, _maxPositionY));
                enemy.gameObject.SetActive(true);
                enemy.Init();

                enemy.OnDied += _bird.OnEnemyDied;
            }
        }
    }
}
