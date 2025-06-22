using UnityEngine;
using UnityEngine.Pool;

public class Pool<T> where T : Poolable
{
    private ObjectPool<T> _pool;

    public Pool(T prefab, int capacity = 100, int maxSize = 10000)
    {
        _pool = new(
            createFunc: () => Object.Instantiate(prefab),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Object.Destroy(obj.gameObject),
            collectionCheck: true,
            maxSize: maxSize,
            defaultCapacity: capacity
        );
    }

    public T Get()
    {
        return _pool.Get();
    }

    public void ReleaseProjectile(T projectile)
    {
        _pool.Release(projectile);
    }
}
