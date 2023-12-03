using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) == true)
        {
            bullet.ResetBullet();
            bullet.gameObject.SetActive(false);
        }

        _bird.Die();
    }
}
