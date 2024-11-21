using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

public class Cat : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody rigidBody;

    private void Update()
    {
        Vector3 moveDirection = gameInput.GetMovementVectorNormalized();
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        // transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime);

        // Jumping looks wrong, and maybe it's clashing with the other movement code, perhaps we need to merge the logic
        // together...
        if (IsGrounded())
        {
            Vector3 jumpForce = new Vector3(0, moveDirection.y, 0);
            rigidBody.AddForce(jumpForce * moveSpeed, ForceMode.Impulse);
        }
    }
    
    private bool IsGrounded()
    {
        return transform.position.y == 0;
    }
}
