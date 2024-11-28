using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObject : MonoBehaviour
{

    [SerializeField]
    private GameObject _shatteredObject;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Floor") && FullGameManager.Instance.gameState == GameState.RUNNING)
        {
            GameObject shattered = Instantiate(_shatteredObject, transform.position, transform.rotation);

            shattered.GetComponent<AudioSource>().Play();

            Destroy(gameObject);
        }
    }
}
