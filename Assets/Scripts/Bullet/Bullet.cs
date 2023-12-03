using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;

    private float _speed;
    private bool _isInitialized;

    private void Update()
    {
        if (_isInitialized == false)
            return;

        transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
    }

    public void Init(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;

        _speed = Random.Range(_minSpeed, _maxSpeed);

        _isInitialized = true;
    }

    public void ResetBullet()
    {
        _isInitialized = false;
    }
}
