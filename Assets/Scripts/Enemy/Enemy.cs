using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : Poolable, IInteractable
{
    [SerializeField] private BirdConfig _bird;
    [SerializeField] private Health _health;
    [SerializeField] private EnemyShooter _shooter;

    private SpriteRenderer _spriteRenderer;

    public override event Action<Poolable> Destroyed;

    public EnemyShooter Shooter => _shooter;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _bird.Sprite;
        _health.ValueRestored += Destroing;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Projectile projectile))
        {
            _health.DecreaseValue(projectile.Damage);
            projectile.Reached();
        }
    }

    private void Destroing()
    {
        _health.ValueRestored -= Destroing;
        Destroy(gameObject);
    }

    public override void Reached()
    {
        Destroyed?.Invoke(this);
    }
}
