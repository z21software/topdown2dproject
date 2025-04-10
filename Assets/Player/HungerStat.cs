using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class HungerStat : MonoBehaviour, IStat
{
    [Header("Player Hunger")]
    [SerializeField] private float _maxHunger = 125.0f;

    [Header("DepletionRate")]
    [SerializeField] private float _hungerDecreaseRate = .075f;
    [SerializeField] private HealthStat _healthStat;
    private float _healthTimer;
    private float _hungerTime;
    private float _currentHunger;
    private bool _isHealthRegenActive;
    private bool _isStarvationActive;

    void Start()
    {
        Hunger = _maxHunger;
    }

    private void Update()
    {
        _hungerTime += Time.deltaTime;
        if (_hungerTime >= 1)
        {
            Decrease(_hungerDecreaseRate);
            _hungerTime = 0;
        }

        HandleHungerEffects();
    }

    private void HandleHungerEffects()
    {
        if(Hunger > 100f && !_isHealthRegenActive)
        {
            _isHealthRegenActive = true;
            _healthTimer = 0;
        }

        if (Hunger <= 0f && !_isStarvationActive)
        {
            _isStarvationActive = true;
            _healthTimer = 0;
        }

        if(_isStarvationActive || _isHealthRegenActive)
        {
            _healthTimer += Time.deltaTime;

            if (_healthTimer >= 5f)
            {
                if(_isHealthRegenActive)
                {
                    _healthStat.Increase(1);
                }
                else if(_isStarvationActive)
                {
                    _healthStat.Decrease(1);
                }
                _healthTimer = 0;
            }
        }

        if (Hunger <= 100f) _isHealthRegenActive = false;
        if (Hunger > 0) _isStarvationActive = false;
    }

    public void Increase(float value)
   {
        Hunger += value;
   }

    public void Decrease(float value)
    {
        Hunger -= value;
    }

    public float Hunger
    {
        get => _currentHunger;
        set
        {
            float newValue = Mathf.Clamp(value, 0, _maxHunger);
            if(_currentHunger != newValue)
            {
                _currentHunger = newValue;
            }
        }
    }
}
