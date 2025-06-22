using UnityEngine;

[CreateAssetMenu(fileName = "New Projectile", menuName = "CreateProjectile", order = 52)]
public class Projectile : ScriptableObject
{
    [SerializeField] private float _damage;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private LayerMask _target;

    public Sprite Sprite => _sprite;
    public float Damage => _damage;
}
