using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float breakableObjectFallHeight;
    [SerializeField] private GameObject breakableObject;

    public void OnAttack()
    {
        Vector3 breakableObjectPosition = getBreakableObjectPosition();
        Destroy(gameObject);
        Instantiate(breakableObject, breakableObjectPosition, transform.rotation);
    }

    private Vector3 getBreakableObjectPosition()
    {
        return new Vector3(transform.position.x, transform.position.y + breakableObjectFallHeight,
            transform.position.z);
    }
}