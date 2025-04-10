using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProperties : MonoBehaviour
{
    [Header("Player stats")]
    [SerializeField] private HealthStat _healthStat;
    [SerializeField] private HungerStat _hungerStat;
    [SerializeField] private float _maxStamina = 100f;

    [Header("Depletion Rates")]
    [SerializeField] private float _hungerDecreaseRate = .05f;
    [SerializeField] private float _staminaRecoveryRate = .1f;
    [SerializeField] private float _healthRecoveryRate = .0f;
    
    private float _currentHunger;
    private float _currentStamina;
    private float _timerHunger = 0;
    
    
    public float Stamina
    {
        get
        {
            return _currentStamina;
        }
        set
        {
            _currentStamina = value;
        }
    }

    void Start()
    {
        _currentStamina = _maxStamina;
    }

    public void DecreaseHealth(int damage) => _healthStat.Decrease(damage);
    public void IncreaseHealth(float value) => _healthStat.Increase(value);

    public void DecreaseHunger(float value) => _hungerStat.Decrease(value);
    public void IncreaseHunger(float value) => _hungerStat.Increase(value);

    public void DecreaseStamina()
    {
        Stamina -= 1;
        Debug.Log(Stamina);
    }
}
