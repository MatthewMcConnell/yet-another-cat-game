using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnterPrompt : MonoBehaviour
{
    private const string TEXT_PREFIX = "Press Enter to "; 
    private const string PREGAME_POSTFIX = "Start the Game";
    private const string INTRO_POSTFIX = "Start Playing";
    private const string FINISHED_POSTFIX = "Restart the Game";
    
    [SerializeField] private TextMeshProUGUI text;
    
    private void Start()
    {
        text.text = TEXT_PREFIX + PREGAME_POSTFIX;
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }
    
    
    private void OnStateChange(object sender, System.EventArgs e)
    {
        switch (FullGameManager.Instance.gameState)
        {
            case GameState.PREGAME:
                Show(PREGAME_POSTFIX);
                break;
            case GameState.INTRO:
                Show(INTRO_POSTFIX);
                break;
            case GameState.FINISHED:
                Show(FINISHED_POSTFIX);
                break;
            case GameState.RUNNING: case GameState.COUNTDOWN:
                Hide();
                break;
        }
    }

    private void Show(string postFix)
    {
        text.text = TEXT_PREFIX + postFix;
        gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
