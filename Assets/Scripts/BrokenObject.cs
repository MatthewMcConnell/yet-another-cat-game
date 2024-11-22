using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObject : MonoBehaviour
{

    [SerializeField]
    private GameObject _shatteredObject;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Floor"))
        {
            Instantiate(_shatteredObject, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
