using UnityEngine;

[CreateAssetMenu(fileName = "New Bird", menuName = "Bird/New Bird", order = 51)]
public class BirdConfig : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private ProjectileConfig _projectile;

    public Sprite Sprite => _sprite;
    public ProjectileConfig Projectile => _projectile;
}
