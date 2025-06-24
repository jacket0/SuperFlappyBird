using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public event Action Fired;
    public event Action Flapped;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Fired?.Invoke();
        }

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Flapped?.Invoke();
        }
    }
}
