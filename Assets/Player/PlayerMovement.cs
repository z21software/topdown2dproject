using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector2 _moveDirection;

    // Update is called once per frame
    public void SetMoveDirection(Vector2 direction)
    {
        _moveDirection = direction;
    }
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }
}
