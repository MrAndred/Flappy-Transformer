using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyPrefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _poolSize;

    private List<Enemy> _enemies = new List<Enemy>();

    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)], _spawnPoint);
            enemy.gameObject.SetActive(false);
            _enemies.Add(enemy);
        }
    }

    public bool TryGetEnemy(out Enemy enemy)
    {
        enemy = _enemies.FirstOrDefault(enemy => !enemy.gameObject.activeSelf);
        return enemy != null;
    }

    public void ResetEnemies()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
