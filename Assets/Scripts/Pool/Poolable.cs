using System;
using UnityEngine;

public abstract class Poolable : MonoBehaviour
{
    public abstract event Action<Poolable> Destroyed;

    public abstract void Reached();
}
