using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStat : MonoBehaviour, IStat
{
    public event Action<float> OnValueChanged;
    public event Action OnValueMin;
    public event Action OnValueMax;
    //public event Action OnValueThreshold;

    [Header("Base settings")]
    [SerializeField] protected float _maxValue;
    [SerializeField] protected float _minValue;
    [SerializeField] protected float _currentValue;
    //[SerializeField] protected float _thresholdValue;

    public float MaxValue => _maxValue;
    public float MinValue => _minValue;
    public float CurrentValue => _currentValue;

    //public float ThresholdValue => _thresholdValue;

    public virtual void Increase(float value)
    {
        SetValue(_currentValue + value);
    }

    public virtual void Decrease(float value)
    {
        SetValue(_currentValue - value);
    }

    protected virtual void SetValue(float newValue)
    {
        newValue = Mathf.Clamp(newValue, _minValue, _maxValue);
        if (Mathf.Approximately(_currentValue, newValue)) return;

        _currentValue = newValue;
        OnValueChanged?.Invoke(_currentValue);

        if (_currentValue <= _minValue) OnValueMin?.Invoke();
        if (_currentValue >= _maxValue) OnValueMax?.Invoke();
        //if (_currentValue >= _thresholdValue) OnValueThreshold?.Invoke();
    }

    protected virtual void Start()
    {
        SetValue(_maxValue);
    }
}
