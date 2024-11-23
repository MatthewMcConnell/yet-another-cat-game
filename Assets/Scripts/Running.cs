using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Running : MonoBehaviour
{
    private const string MONSTERS_ALIVE_PREFIX = "Monsters Alive: ";
    
    [SerializeField] private TextMeshProUGUI monstersAliveText;
    
    private void Start()
    {
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }

    private void Update()
    {
        monstersAliveText.text = MONSTERS_ALIVE_PREFIX + FullGameManager.Instance.GetMonstersLeft();
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
