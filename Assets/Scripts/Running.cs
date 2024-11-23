using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Running : MonoBehaviour
{
    private void Start()
    {
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }
    
    private void OnStateChange(object sender, EventArgs e)
    {
        switch (FullGameManager.Instance.gameState)
        {
            case GameState.RUNNING:
                Show();
                break;
            default:
                Hide();
                break;
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
