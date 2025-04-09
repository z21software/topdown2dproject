using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Vector3 _direction = Vector3.up; // Настраивайте в инспекторе!

    private void Start()
    {
        Destroy(gameObject, _duration);
    }

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
