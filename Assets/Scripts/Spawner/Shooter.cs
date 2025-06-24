using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected Projectile _prefab;
    [SerializeField] protected Transform _transform;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _fireRate = 1f;
    [SerializeField] protected bool _isLeftDirection;

    protected Pool<Projectile> _projectilePool;

    protected void Shoot(Vector3 position, Vector3 direction)
    {
        var projectile = _projectilePool.Get();
        projectile.Destroyed += OnDestroyed;
        projectile.transform.position = position;
        projectile.transform.right = direction;
        projectile.Launch(direction, _speed);
    }

    private void OnDestroyed(Poolable poolable)
    {
        poolable.Destroyed -= OnDestroyed;
        _projectilePool.Release(poolable as Projectile);
    }
}
