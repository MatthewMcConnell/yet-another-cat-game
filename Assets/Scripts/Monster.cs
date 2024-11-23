using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float breakableObjectFallHeight;
    [SerializeField] private GameObject breakableObject;

    public void OnAttack()
    {
        Vector3 breakableObjectPosition = GetBreakableObjectPosition();
        gameObject.SetActive(false);
        Instantiate(breakableObject, breakableObjectPosition, transform.rotation);
        FullGameManager.Instance.OnMonsterDied();
    }

    private Vector3 GetBreakableObjectPosition()
    {
        return new Vector3(transform.position.x, transform.position.y + breakableObjectFallHeight,
            transform.position.z);
    }

    public void Spawn()
    {
        Debug.Log("I have spawned");
        gameObject.SetActive(true);
    }
}