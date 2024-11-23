using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PreGame : MonoBehaviour
{
    [SerializeField] private Image background;
    
    private void Start()
    {
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }
    
    private void OnStateChange(object sender, EventArgs e)
    {
        switch (FullGameManager.Instance.gameState)
        {
            case GameState.PREGAME:
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