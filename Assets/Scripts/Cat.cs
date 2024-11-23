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

    private void Start()
    {
        gameInput.AddAttackListener(OnAttack);
    }

    private void OnAttack(object sender, EventArgs e)
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, attackRange))
        {
            if (raycastHit.transform.TryGetComponent(out Monster monster))
            {
                gameObject.GetComponent<AudioSource>().Play();
                monster.OnAttack();
            }
        }
    }
}
