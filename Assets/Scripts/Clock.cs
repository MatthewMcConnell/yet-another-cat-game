using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    
    private void Start()
    {
        gameObject.SetActive(false);
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }
    
    private void Update()
    {
        timerImage.fillAmount = FullGameManager.Instance.GetGameTime();
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
