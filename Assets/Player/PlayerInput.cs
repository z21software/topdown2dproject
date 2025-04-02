using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    private PlayerControls _player—ontrols;
    private Vector2 _moveDirection;
    // Update is called once per frame
    private void Awake()
    {
        _player—ontrols = new PlayerControls();
        _player—ontrols.Player.Movement.performed += OnMovement;
        _player—ontrols.Player.Movement.canceled += OnMovement;
    }

    private void OnEnable()
    {
        _player—ontrols.Enable();
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
        _playerMovement?.SetMoveDirection(_moveDirection);

    }
}
