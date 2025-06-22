using UnityEngine;

[CreateAssetMenu(fileName = "New Bird", menuName = "Bird/New Bird", order = 51)]
public class Bird : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Projectile _projectile;

    public Sprite Sprite => _sprite;
    public Projectile Projectile => _projectile;
}
