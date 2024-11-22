using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    // TODO: let's denormalize this one so we can better handle it later...
    public Vector3 GetMovementVectorNormalized()
    {
        return playerInputActions.Player.Move.ReadValue<Vector3>();
    }
}
