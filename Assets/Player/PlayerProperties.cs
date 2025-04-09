using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProperties : MonoBehaviour
{
    [Header("Starting Values")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _maxStamina = 100f;

    [Header("Depletion Rates")]
    [SerializeField] private float _hungerDecreaseRate = .05f;
    [SerializeField] private float _staminaRecoveryRate = .1f;
    [SerializeField] private float _healthRecoveryRate = .0f;

    [HeaderAttribute("UI")]
    [SerializeField] private TextMeshProUGUI _healthUI;
    [SerializeField] private TextMeshProUGUI _hungerUI;
    [SerializeField] private TextMeshProUGUI _staminaUI;
    
    private int _currentHealth;
    private float _currentHunger;
    private float _currentStamina;
    private float _timerHunger = 0;
    private float _timerHealth = 0;
    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }
    
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
    
    public float Hunger
    {
        get
        {
            return _currentHunger;
        }
        set
        {
            _currentHunger = value;
        }
    }

    void Start()
    {
        _currentHealth = _maxHealth;
        _currentHunger = _maxHunger;
        _currentStamina = _maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHunger();
        UpdatePropertiesUI();
        _timerHunger += Time.deltaTime; //временный костыль
        
        if(Hunger <= 0 && _timerHunger >= 5)
        {
            DecreaseHealth(1);
            _timerHunger = 0;
        }

        _timerHealth += Time.deltaTime; //временный костыль
        if (Hunger >= 90 && Health < 100 && _timerHealth >= 5)
        {
            IncreaseHealth(1);
            _timerHealth = 0;
        }
    }

    private void UpdateHunger()
    {
        DecreaseHunger();
    }

    public void IncreaseHealth(int heal)
    {
        Health += heal;
    }

    public void DecreaseHealth(int damage)
    {
        Health = Mathf.Clamp(Health - damage, 0, _maxHealth);
        Debug.Log(Health);
        if (Health <= 0) Destroy(gameObject);
    }

    public void IncreaseHunger(float hungerAmount)
    {
        Hunger = Mathf.Clamp(Hunger + hungerAmount, 0, _maxHunger);

        Debug.Log($"Hunger Increased bb {hungerAmount}, current hHunger: {Hunger}/{_maxHunger}");
    }
    
    public void DecreaseHunger()
    {
        Hunger = Mathf.Clamp(Hunger - _hungerDecreaseRate * Time.deltaTime, 0, Hunger);
        Debug.Log($"Hunger Decreased by {_hungerDecreaseRate}, current Hunger: {Hunger}/{_maxHunger}");
    }

    public void DecreaseStamina()
    {
        Stamina -= 1;
        Debug.Log(Stamina);
    }

    void UpdatePropertiesUI()
    {
        _healthUI.text = Health.ToString();
        _hungerUI.text = Mathf.RoundToInt(Hunger).ToString();
        _staminaUI.text = Stamina.ToString();
    }
}
