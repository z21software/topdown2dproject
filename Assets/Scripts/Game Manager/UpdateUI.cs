using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _healthUI;
    [SerializeField] private TextMeshProUGUI _hungerUI;
    [SerializeField] private TextMeshProUGUI _thirstUI;
    [SerializeField] private TextMeshProUGUI _staminaUI;

    [Header("Stats components")]
    [SerializeField] private HealthStat _healthStat;
    [SerializeField] private HungerStat _hungerStat;
    [SerializeField] private ThristStat _thirstStat;

    private int _lastThirst;

    private void Start()
    {
        _healthStat.OnValueChanged += UpdateHealthUI;
        _hungerStat.OnValueChanged += UpdateHungerUI;
        _thirstStat.OnValueChanged += UpdateThirstUI;

        UpdateHealthUI(_healthStat.CurrentValue);
        UpdateHungerUI(_hungerStat.CurrentValue);
        UpdateThirstUI(_thirstStat.CurrentValue);
    }
    private void UpdateThirstUI(float thirst)
    {
        _thirstUI.text = Mathf.FloorToInt(thirst).ToString();
    }
    private void UpdateHungerUI(float hunger)
    {
        _hungerUI.text = Mathf.FloorToInt(hunger).ToString();
    }

    private void UpdateHealthUI(float health)
    {
        _healthUI.text = Mathf.FloorToInt(health).ToString();
    }

    private void OnDestroy()
    {
        _healthStat.OnValueChanged -= UpdateHealthUI;
        _hungerStat.OnValueChanged -= UpdateHungerUI;
        _thirstStat.OnValueChanged -= UpdateThirstUI;
    }
}
