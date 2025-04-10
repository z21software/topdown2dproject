using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStat : MonoBehaviour, IStat 
{
    [Header("Player Health")]
    [SerializeField] private float _maxHealth = 100f;

    [Header("Depletion Rate")]
    [SerializeField] private float _healthRecoveryRate = .25f;

    private float _currentHealth;

    public void Increase(float value)
    {
        Health += value;
    }

    public void Decrease(float value)
    {
        Health -= value;
        Debug.Log(Health);
    }

    private void Start()
    {
        Health = _maxHealth;
    }

    public float Health
    {
        get => _currentHealth;
        set
        {
            float newValue = Mathf.Clamp(value, 0, _maxHealth);
            if(_currentHealth != newValue)
            {
                _currentHealth = newValue;
                //change health action invoke;

                if(_currentHealth <= 0)
                {
                    Destroy(gameObject);
                    //death
                    //death action invoke
                }
            }
        }
    }
}
