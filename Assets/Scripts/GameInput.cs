using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private event EventHandler OnPlayerAttack;
    private event EventHandler OnEnterPressed;
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Attack.performed += PlayerAttacked;
        playerInputActions.Player.Skip.performed += EnterPressed;
    }

    public Vector2 GetMousePan()
    {
        Vector2 mouseDelta = playerInputActions.Player.Look.ReadValue<Vector2>();
        return mouseDelta;
    }

    private void PlayerAttacked(InputAction.CallbackContext context)    
    {
        OnPlayerAttack?.Invoke(this, EventArgs.Empty);
    }

    private void EnterPressed(InputAction.CallbackContext context)
    {
        OnEnterPressed?.Invoke(this, EventArgs.Empty);
    }

    public void AddAttackListener(EventHandler listener)
    {
        OnPlayerAttack += listener;
    }
    
    public void AddEnterPressedListener(EventHandler listener)
    {
        OnEnterPressed += listener;
    }
}
