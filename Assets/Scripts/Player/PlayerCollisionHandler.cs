using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public Action<IInteractable> CollisionDetected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IInteractable obj))
        {
            CollisionDetected?.Invoke(obj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable obj))
        {
            CollisionDetected?.Invoke(obj);
        }
    }
}
