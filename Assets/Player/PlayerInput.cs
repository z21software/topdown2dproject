using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Inventory;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 2f;
    [SerializeField] private LayerMask _interactableLayer;
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

    public void OnInventoryItemRotate(InputValue inputValue) //R
    {

    }

    public void OnInventory(InputValue inputValue) //tab
    {

    }

    public void OnMenu(InputValue inputValue) //esc
    {

    }

    public void OnLoot(InputValue inputValue) //E
    {
        if(inputValue.isPressed)
        {
            Vector2 direction = transform.right;
            RaycastHit2D hit = Physics2D.Raycast(
                    transform.position,
                    direction,
                    _interactionDistance,
                    _interactableLayer
                );

            Debug.DrawRay(transform.position, direction * _interactionDistance, Color.red, 1f);
           
            
            if(hit.collider.CompareTag("Item"))
            {
                //
            }
            else if(hit.collider.CompareTag("Container"))
            {
                //
            }
        }
        
    }
    
}
