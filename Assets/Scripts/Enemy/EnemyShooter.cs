using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private Weapon _weapon;

    private Coroutine _shooting;
    private bool _isInitialized;

    public void Init()
    {
        _isInitialized = true;
        _weapon.Init();
        _shooting = StartCoroutine(ShootByPeriod());
    }

    public IEnumerator ShootByPeriod()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_shootDelay);

        while (_isInitialized == true)
        {
            _weapon.Shoot();

            yield return waitForSeconds;
        }
    }

    public void StopShooting()
    {
        _isInitialized = false;
        StopCoroutine(_shooting);
    }
}
