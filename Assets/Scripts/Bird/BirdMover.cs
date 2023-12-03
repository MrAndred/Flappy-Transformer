using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _toucForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationAngleZ;
    [SerializeField] private float _minRotationAngleZ;

    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        transform.position = _startPosition;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationAngleZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationAngleZ);

        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(_speed, 0);
            transform.rotation = _maxRotation;
            _rigidbody2D.AddForce(Vector2.up * _toucForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        _rigidbody2D.velocity = Vector2.zero;
    }
}
