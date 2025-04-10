using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _healthUI;
    [SerializeField] private TextMeshProUGUI _hungerUI;
    [SerializeField] private TextMeshProUGUI _staminaUI;

    [Header("Stats components")]
    [SerializeField] private HealthStat _healthStat;
    [SerializeField] private HungerStat _hungerStat;

    private int _lastHealth;
    private int _lastHunger;

    void Update()
    {
        int currentHealth = Mathf.FloorToInt(_healthStat.Health);
        int currentHunger = Mathf.FloorToInt(_hungerStat.Hunger);

        if(currentHealth != _lastHealth)
        {
            _healthUI.text = currentHealth.ToString();
            _lastHealth = currentHealth;
        }

        if (currentHunger != _lastHunger)
        {
            _hungerUI.text = currentHunger.ToString();
            _lastHunger = currentHunger;
        }
    }
}
