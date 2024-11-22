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
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Attack.performed += PlayerAttacked;
    }

    // TODO: let's denormalize this one so we can better handle it later...
    public Vector3 GetMovementVectorNormalized()
    {
        return playerInputActions.Player.Move.ReadValue<Vector3>();
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

    public void addAttackListener(EventHandler listener)
    {
        OnPlayerAttack += listener;
    }
}
