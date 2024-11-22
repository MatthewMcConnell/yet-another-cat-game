using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public void OnAttack()
    {
        Debug.Log("Monster Attacked!");
        Debug.Log("Destroying Monster " + gameObject.name);
        Destroy(gameObject);
    }
}
