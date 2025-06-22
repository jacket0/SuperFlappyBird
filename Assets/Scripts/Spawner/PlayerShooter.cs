using UnityEngine;

public class PlayerShooter : Shooter
{
    private void Awake()
    {
        _projectilePool = new Pool<RegularProjectile>(_prefab);
    }

    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position, transform.right);
        Debug.DrawRay(transform.position, transform.right, Color.red);

        if (Input.GetKey(KeyCode.Space) && _currentFireTime >= _fireRate)
        {
            Shoot(transform.position, transform.right);
            _currentFireTime = 0;
        }

        _currentFireTime += Time.deltaTime;
    }
}
