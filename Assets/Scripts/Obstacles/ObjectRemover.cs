using UnityEngine;

public class ObjectRemover : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Projectile obj))
        {
            obj.Reached();
        }
    }
}
