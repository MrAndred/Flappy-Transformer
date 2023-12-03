using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) == true)
        {
            bullet.ResetBullet();
            bullet.gameObject.SetActive(false);
        }

        _enemy.Die();
    }
}
