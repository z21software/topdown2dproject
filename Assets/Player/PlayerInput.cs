using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Inventory; 
using UI;

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
        _player—ontrols.Player.Inventory.performed += OnInventory;
        _player—ontrols.Player.Loot.performed += OnLoot;
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

    public void OnInventory(InputAction.CallbackContext context) //tab
    {
        Debug.Log("Key pressed");
        UIController.Instance.TurnCanvasInventory();
        UIController.Instance.SetActiveLootPanel(false);
    }

    public void OnMenu(InputValue inputValue) //esc
    {
        //UIController.Instance
    }

    public void OnLoot(InputAction.CallbackContext context) //E
    {
        Vector2 direction = transform.right;
        RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                direction,
                _interactionDistance,
                _interactableLayer
            );

        Debug.DrawRay(transform.position, direction * _interactionDistance, Color.red, 1f);

        if (hit.collider != null)
        {
            //if (hit.collider.CompareTag("Item"))
            //{
                //
            //}
            if (hit.collider.CompareTag("Container"))
            {
                StartCoroutine(IventoryManager.Instance.CreatePanel(
                    IventoryManager.Instance.GetPanel(
                        PanelScript.Type.Loot
                        ),
                    hit.transform.parent.GetComponent<LootData>()
                    )
                );
                UIController.Instance.SetActiveLootPanel(true);
                UIController.Instance.SetCanvasInventory(true);
            }
        }
    }
}
