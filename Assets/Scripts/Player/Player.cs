using UnityEngine;

[RequireComponent (typeof(SpriteRenderer), typeof(PlayerInteractionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private BirdConfig _bird;
    [SerializeField] private PlayerInteractionHandler _collisionHandler;
    [SerializeField] private Health _health;
    [SerializeField] private PlayerControl _control;
    [SerializeField] private PlayerShooter _shooter;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _collisionHandler = GetComponent<PlayerInteractionHandler>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _bird.Sprite;
        _collisionHandler.InteractionDetected += DetermineCollision;
        _health.ValueRestored += Destroing;
        _control.Fired += _shooter.Fire;
        _control.Flapped += _mover.Flapping;
    }

    private void OnDisable()
    {
        _collisionHandler.InteractionDetected -= DetermineCollision;
        _control.Fired -= _shooter.Fire;
        _control.Flapped -= _mover.Flapping;
    }

    public void DetermineCollision(IInteractable collision)
    {
        if (collision is Obstacle)
        {
            Destroing();
        }
        else if (collision is Projectile projectile)
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
