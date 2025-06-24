using System.Collections;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] private float _lowerPosition;
    [SerializeField] private float _upperPosition;
    [SerializeField] private float _spawnRate = 1;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(StartSpawn());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator StartSpawn()
    {
        var wait = new WaitForSeconds(_spawnRate);
            
        while (enabled)
        {
            Enemy enemy = Spawn() as Enemy;
            enemy.Shooter.StartAttack(enemy.transform.position);
            yield return wait;
        }
    }

    protected override void ConfigureObject(Poolable obj)
    {
        var spawnPositionY = Random.Range(_lowerPosition, _upperPosition);
        Vector2 newPosition = new Vector2(transform.position.x, spawnPositionY);

        obj.transform.position = newPosition;
    }
}
