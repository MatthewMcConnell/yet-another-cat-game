using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Cat : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float rotationSensitivity;
    [SerializeField] private float attackRange;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Rigidbody rigidBody;

    private void Start()
    {
        gameInput.addAttackListener(OnAttack);
    }

    private void Update()
    {
        Vector3 moveDirection = gameInput.GetMovementVectorNormalized();
        moveForwardOrBack(moveDirection);
        rotate(gameInput.GetMousePan());
        ensureZRotationIsZero();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = gameInput.GetMovementVectorNormalized();
        tryJump(moveDirection);
    }

    private void OnAttack(object sender, EventArgs e)
    {
        Debug.Log("Cat Attacked!");
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, attackRange))
        {
            Debug.Log("CAT HIT SOMETHING!");   
            if (raycastHit.transform.TryGetComponent(out Monster monster))
            {
                Debug.Log("WAS A MONSTER!");
                monster.OnAttack();
            }
        }
    }
    
    private void ensureZRotationIsZero()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
    }
    
    private void rotate(Vector2 pan)
    {
        transform.Rotate(Vector3.up, pan.x * rotationSensitivity, Space.Self);
    }

    private void moveForwardOrBack(Vector3 moveDirection)
    {
        Vector3 fbMoveDirection = transform.forward * moveDirection.z;
        transform.position += fbMoveDirection * (moveSpeed * Time.deltaTime);
    }

    private void tryJump(Vector3 moveDirection)
    {
        if (shouldJump(moveDirection))
        {
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private bool shouldJump(Vector3 moveDirection)
    {
        return IsGrounded() && moveDirection.y > 0;
    }
    
    private bool IsGrounded()
    {
        Vector3 position = transform.position;
        float raycastStartHeight = 0.1f;
        float touchingGroundWithinDistance = 0.2f;
        Vector3 raycastStart = new Vector3(position.x, position.y + raycastStartHeight, position.z);
        bool isGrounded = Physics.Raycast(raycastStart, Vector3.down, touchingGroundWithinDistance);
        return isGrounded;
    }
}
