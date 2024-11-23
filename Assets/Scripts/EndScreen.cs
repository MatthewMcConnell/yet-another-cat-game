using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private Image winBackground;
    [SerializeField] private Image loseBackground;
    
    private void Start()
    {
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }
    
    private void OnStateChange(object sender, EventArgs e)
    {
        switch (FullGameManager.Instance.gameState)
        {
            case GameState.FINISHED:
                Show();
                break;
            default:
                Hide();
                break;
        }
    }

    private void Show()
    {
        selectRightBackground();
        gameObject.SetActive(true);
    }
    
    private void selectRightBackground()
    {
        if (FullGameManager.Instance.hasPlayerWon)
        {
            winBackground.gameObject.SetActive(true);
            loseBackground.gameObject.SetActive(false);
        }
        else
        {
            winBackground.gameObject.SetActive(false);
            loseBackground.gameObject.SetActive(true);
        }
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
