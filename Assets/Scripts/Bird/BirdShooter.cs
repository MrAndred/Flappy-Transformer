using UnityEngine;

public class BirdShooter : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private bool _isInitialized = false;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _isInitialized = true;
    }

    private void Update()
    {
        if (_isInitialized == false)
            return;

        if (Input.GetMouseButtonDown(0) == true)
        {
            _weapon.Shoot();
        }
    }
}
