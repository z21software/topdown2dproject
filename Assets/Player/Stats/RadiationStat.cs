using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationStat : BaseStat
{
    [SerializeField] HealthStat _healthStat;
    [SerializeField] private float _radiationThreshold = 20f;
    [SerializeField] private float _increaseRadiation = 1f;
    [SerializeField] private float _startRadiation = 0f;
    private float _radiationTimer;

    private void Update()
    {
        _radiationTimer += Time.deltaTime;
        if (CurrentValue >= _radiationThreshold && _radiationTimer >= 1f)
        {
            _healthStat.Decrease(1f);
            _radiationTimer = 0f;
        }
    }

    protected override void Start()
    {
        base.SetValue(_startRadiation);
    }


}
