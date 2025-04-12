using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour, IDrinkable
{
    [SerializeField] private HealthStat _healthStat;
    [SerializeField] private ThristStat _thristStat;
    [SerializeField] private float _thirstRestore = 100f;
    [SerializeField] private float _healthPenalty = 10f;
    public float GetDrinkValue() => _thirstRestore;
    public float GetQuality() => .3f;

    public void Drink()
    {
        _thristStat.Increase(GetDrinkValue());
        _healthStat.Decrease(_healthPenalty);
    }
}
