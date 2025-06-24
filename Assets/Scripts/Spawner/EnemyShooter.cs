using System.Collections;
using UnityEngine;

public class EnemyShooter : Shooter
{
    private Coroutine _coroutine;
    
    public float FireRate => _fireRate;

    private void Awake()
    {
        _projectilePool = new Pool<Projectile>(_prefab);
    }

    public void StartAttack(Vector3 position)
    {
        _coroutine = StartCoroutine(Attack(position));
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Attack(Vector3 position)
    {
        var wait = new WaitForSeconds(FireRate);

        while (enabled)
        {
            Shoot(position, transform.right * -1);
            yield return wait;
        }
    }
}
