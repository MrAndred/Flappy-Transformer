using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BulletPool _bulletPool;

    public void Init()
    {
        _bulletPool.ResetBullets();
    }

    public void Shoot()
    {
        if (_bulletPool.TryGetBullet(out Bullet bullet) == true)
        {
            bullet.Init(_shootPoint.position, _shootPoint.rotation);
            bullet.gameObject.SetActive(true);

            _bulletPool.DisableBulletAbroadScreen();
        }
    }
}
