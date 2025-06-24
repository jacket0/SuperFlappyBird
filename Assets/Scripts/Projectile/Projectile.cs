using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Projectile : Poolable, IInteractable
{
    [SerializeField] ProjectileConfig _projectile;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    public override event Action<Poolable> Destroyed;
    public Sprite Sprite => _projectile.Sprite;
    public float Damage => _projectile.Damage;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _projectile.Sprite;
    }

    public override void Reached()
    {
        Destroyed?.Invoke(this);
    }

    public void Launch(Vector2 direction, float speed)
    {
        _rigidbody.velocity = direction * speed;
    }
}
