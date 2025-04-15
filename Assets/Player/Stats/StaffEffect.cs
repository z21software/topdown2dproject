using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffEffect : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private BaseStat _targetStat;
    [SerializeField] private HealthStat _healthStat;
    [SerializeField] private float _healThreshold = 100f;
    [SerializeField] float _effectInterval = 5f;
    [SerializeField] float _healthDamageAmount = 1f;
    [SerializeField] float _healAmount = 1f;
    
    //[Header("Radiation")]
    //[SerializeField] private RadiationStat _radiationStat;
    //[SerializeField] private float _radiationThreshold = 20f;
    //[SerializeField] private float _readiationMultiplyer = 1.25f;
    //[SerializeField] bool _isRadioactive = false;

    private Coroutine _activeDamageRoutine;
    private Coroutine _activeHealRoutine;
    //private Coroutine _activeRadiationDamage;

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
        //_radiationStat.OnValueThreshold += StartRadiationEffect;
    }

    private void HandleValueChange(float newValue)
    {
        // Останавливаем эффекты при выходе из крайних состояний
        if (newValue > 0 && _activeDamageRoutine != null)
        {
            StopCoroutine(_activeDamageRoutine);
            _activeDamageRoutine = null;
        }

        if (newValue < _healThreshold && _activeHealRoutine != null)
        {
            StopCoroutine(_activeHealRoutine);
            _activeHealRoutine = null;
        }

        /*if(_radiationStat.CurrentValue < _radiationThreshold && _activeRadiationDamage != null)
        {
            StopCoroutine(_activeRadiationDamage);
            _activeRadiationDamage = null;
        }*/
    }

    /*private void StartRadiationEffect()
    {
        if(_activeRadiationDamage == null && _radiationStat.CurrentValue >= _radiationThreshold)
        {
            _activeRadiationDamage = StartCoroutine(ApplyRadiation());
        }
    }*/

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

    /*private IEnumerator ApplyRadiation()
    {
        while(true)
        {
            _healthDamageAmount = _healthDamageAmount * _readiationMultiplyer;
            _healthStat.Decrease(_healthDamageAmount);
            Debug.Log($"Applying radiation damage: {_healthDamageAmount}");
            yield return new WaitForSeconds(_effectInterval / _readiationMultiplyer);
        }
    }*/

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
        //_radiationStat.OnValueThreshold -= StartRadiationEffect;
    }
}
