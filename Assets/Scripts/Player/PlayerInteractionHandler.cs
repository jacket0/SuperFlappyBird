using System;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    public Action<IInteractable> InteractionDetected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IInteractable obj))
        {
            InteractionDetected?.Invoke(obj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable obj))
        {
            InteractionDetected?.Invoke(obj);
        }
    }
}
