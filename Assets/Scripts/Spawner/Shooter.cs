using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected RegularProjectile _prefab;
    [SerializeField] protected Transform _transform;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _fireRate = 1f;
    [SerializeField] protected bool _isLeftDirection;

    protected Pool<RegularProjectile> _projectilePool;
    protected float _currentFireTime;

    protected void Shoot(Vector3 position, Vector3 direction)
    {
        var projectile = _projectilePool.Get();
        projectile.Destroyed += OnDestroyed;
        projectile.transform.position = position;
        projectile.transform.right = direction;
        projectile.Launch(direction, _speed);
    }

    protected void OnDestroyed(RegularProjectile projectile)
    {
        projectile.Destroyed -= OnDestroyed;
        _projectilePool.ReleaseProjectile(projectile);
    }
}
