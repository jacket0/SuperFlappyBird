using UnityEngine;

public class PlayerShooter : Shooter
{
    private float _currentFireTime;

    private void Awake()
    {
        _projectilePool = new Pool<Projectile>(_prefab);
    }

    private void Update()
    {
        _currentFireTime += Time.deltaTime;
    }

    public void Fire()
    {
        if (_currentFireTime >= _fireRate)
        {
            Shoot(transform.position, transform.right);
            _currentFireTime = 0;
        }
    }
}
