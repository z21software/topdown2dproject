using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;
    void Start()
    {
        Destroy(gameObject, _duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
