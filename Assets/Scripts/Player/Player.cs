using UnityEngine;

[RequireComponent (typeof(SpriteRenderer), typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Bird _bird;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private Health _health;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _bird.Sprite;
        _collisionHandler.CollisionDetected += DetermineCollision;
        _health.ValueRestored += Destroing;
    }

    public void DetermineCollision(IInteractable collision)
    {
        if (collision is Obstacle)
        {
            Destroing();
        }
        else if (collision is RegularProjectile projectile)
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
}
