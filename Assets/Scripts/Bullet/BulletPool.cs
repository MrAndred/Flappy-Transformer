using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _poolSize;

    private List<Bullet> _bullets = new List<Bullet>();
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;

        for (int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, _spawnPoint);
            bullet.gameObject.SetActive(false);
            _bullets.Add(bullet);
        }
    }

    public bool TryGetBullet(out Bullet bullet)
    {
        bullet = _bullets.FirstOrDefault(bullet => !bullet.gameObject.activeSelf);
        return bullet != null;
    }

    public void ResetBullets()
    {
        foreach (var bullet in _bullets)
        {
            bullet.ResetBullet();
            bullet.gameObject.SetActive(false);
        }
    }

    public void DisableBulletAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var bullet in _bullets)
        {
            if (bullet.transform.position.x < disablePoint.x)
            {
                bullet.ResetBullet();
                bullet.gameObject.SetActive(false);
            }
        }
    }
}
