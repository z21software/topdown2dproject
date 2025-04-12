using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThristStat : BaseStat
{
    [SerializeField] private float _decreaseRate = .1f;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 1f)
        {
            Decrease(_decreaseRate);
            _timer = 0f;
        }
    }
}
