using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    private float _duration = .5f;
    private float _speed = 2f;
    private Vector3 _direction = Vector3.up;
    public void Initialize()
    {
        Destroy(gameObject, _duration);
    }

    private void Update()
    {
        transform.position += _direction * Time.deltaTime * _speed;
    }
}
