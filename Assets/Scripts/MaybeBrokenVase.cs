using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaybeBrokenVase : MonoBehaviour
{
    private void Start()
    {
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }

    private void OnStateChange(object sender, EventArgs e)
    {
        switch (FullGameManager.Instance.gameState)
        {
            case GameState.PREGAME:
                Despawn();
                break;
        }
    }

    private void Despawn()
    {
        FullGameManager.Instance.OnStateChange -= OnStateChange;
        Destroy(gameObject);
    }
}
