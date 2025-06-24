using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected int _poolCapacity = 5;
    [SerializeField] protected int _poolMaxSize = 5;

    [SerializeField] private Poolable _prefab;

    private Pool<Poolable> _pool;

    private void Awake()
    {
        _pool = new Pool<Poolable>(_prefab, _poolCapacity, _poolMaxSize);
    }

    public Poolable Spawn()
    {
        var obj = _pool.Get();
        ConfigureObject(obj);

        return obj;
    }

    protected abstract void ConfigureObject(Poolable obj);

    protected void OnDestroyed(Poolable obj)
    {
        obj.Destroyed -= OnDestroyed;
        _pool.Release(obj);
    }
}
