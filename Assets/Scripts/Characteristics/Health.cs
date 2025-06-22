using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value = 100;

    public event Action<float, float> ValueChanged;
    public event Action ValueRestored;

    public float MaxValue { get; private set; }
    public float MinValue { get; } = 0;

    private void Awake()
    {
        MaxValue = _value;
    }

    public void DecreaseValue(float damage)
    {
        if (damage > 0)
        {
            _value -= damage;
            _value = Mathf.Max(_value, MinValue);
            ValueChanged?.Invoke(_value, MaxValue);
        }

        if (_value == 0)
        {
            ValueRestored?.Invoke();
        }
    }

    public void IncreaseValue(float heal)
    {
        if (heal > 0)
        {
            _value += heal;
            _value = Mathf.Min(_value, MaxValue);
            ValueChanged?.Invoke(_value, MaxValue);
        }
    }
}
