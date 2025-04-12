using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthStat : BaseStat
{
    public event Action OnDeath;
    [Header("Health settings")]
    [SerializeField] private float _healthRecovery = .25f;

    protected override void SetValue(float newValue)
    {
        base.SetValue(newValue);
        if (newValue <= 0) OnDeath?.Invoke();
    }
}
