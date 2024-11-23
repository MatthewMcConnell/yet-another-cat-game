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
    [SerializeField] private float attackRange;
    [SerializeField] private GameInput gameInput;
    
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Start()
    {
        gameInput.AddAttackListener(OnAttack);
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }
    
    private void OnStateChange(object sender, EventArgs e)
    {
        switch (FullGameManager.Instance.gameState)
        {
            case GameState.COUNTDOWN:
                resetPosition();
                break;
        }
    }

    private void resetPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    private void OnAttack(object sender, EventArgs e)
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, attackRange))
        {
            if (raycastHit.transform.TryGetComponent(out Monster monster))
            {
                //gameObject.GetComponent<AudioSource>().Play();
                monster.OnAttack();
            }
        }
    }
}
