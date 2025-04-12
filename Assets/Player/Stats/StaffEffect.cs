using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffEffect : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private BaseStat _targetStat;
    [SerializeField] private HealthStat _healthStat;
    [SerializeField] private float _targetPositiveEffect = 100f;
    [SerializeField] float _effectInterval = 5f;
    [SerializeField] float _healthDamageAmount = 1f;
    [SerializeField] float _healAmount = 1f;

    private Coroutine _activeDamageRoutine;
    private Coroutine _activeHealRoutine;

    void Start()
    {
        if (_targetStat == null || _healthStat == null)
        {
            Debug.LogError("Assign all required stats in the inspector!", gameObject);
            enabled = false;
            return;
        }

        _targetStat.OnValueChanged += HandleValueChange;
        _targetStat.OnValueMin += StartNegativeEffect;
        _targetStat.OnValueMax += StartPositiveEffect;
    }

    private void StartPositiveEffect()
    {
        if (_activeHealRoutine == null && _healthStat.CurrentValue < _healthStat.MaxValue)
        {
            _activeHealRoutine = StartCoroutine(ApplyHeal());
        }
    }

    private void StartNegativeEffect()
    {
        if (_activeDamageRoutine == null)
        {
            _activeDamageRoutine = StartCoroutine(ApplyDamage());
        }
    }

    private void HandleValueChange(float newValue)
    {
        // Останавливаем эффекты при выходе из крайних состояний
        if (newValue > 0 && _activeDamageRoutine != null)
        {
            StopCoroutine(_activeDamageRoutine);
            _activeDamageRoutine = null;
        }

        if (newValue < _targetPositiveEffect && _activeHealRoutine != null)
        {
            StopCoroutine(_activeHealRoutine);
            _activeHealRoutine = null;
        }
    }

    private IEnumerator ApplyDamage()
    {
        while (true)
        {
            _healthStat.Decrease(_healthDamageAmount);
            Debug.Log($"Applying damage: {_healthDamageAmount}");
            yield return new WaitForSeconds(_effectInterval);
        }
    }

    private IEnumerator ApplyHeal()
    {
        while (true)
        {
            _healthStat.Increase(_healAmount);
            Debug.Log($"Applying heal: {_healAmount}");
            yield return new WaitForSeconds(_effectInterval);
        }
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        if (_targetStat == null) return;

        _targetStat.OnValueMin -= StartNegativeEffect;
        _targetStat.OnValueMax -= StartPositiveEffect;
        _targetStat.OnValueChanged -= HandleValueChange;
    }
}
