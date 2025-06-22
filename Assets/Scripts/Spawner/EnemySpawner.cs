using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;
    [SerializeField] private float _lowerPosition;
    [SerializeField] private float _upperPosition;
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private Enemy _prefab;

    private Pool<Enemy> _pool;
    private Coroutine _coroutine;

    private void Awake()
    {
        _pool = new Pool<Enemy>(_prefab, _poolCapacity, _poolMaxSize);
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(StartSpawn());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private Enemy Spawn()
    {
        var spawnPositionY = Random.Range(_lowerPosition, _upperPosition);
        Vector2 newPosition = new Vector2(transform.position.x, spawnPositionY);
        var obj = _pool.Get();
        obj.transform.position = newPosition;

        return obj;
    }

    private IEnumerator StartSpawn()
    {
        var wait = new WaitForSeconds(_spawnRate);

        while (enabled)
        {
            Enemy enemy = Spawn();
            enemy.Shooter.StartAttack(enemy.transform.position);
            yield return wait;
        }
    }
}
