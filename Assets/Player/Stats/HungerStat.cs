using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class HungerStat : BaseStat

{
    [SerializeField] private float _decreaseRate = .05f;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= 1f)
        {
            Decrease(_decreaseRate);
            _timer = 0f;
        }
    }
}
