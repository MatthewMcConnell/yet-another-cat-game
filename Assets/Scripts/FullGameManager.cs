using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullGameManager : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;

    public static FullGameManager Instance { get; private set; }
    public GameState gameState { get; private set; }
    
    public event EventHandler OnStateChange;

    private void Awake()
    {
        Instance = this;
        gameState = GameState.PREGAME;
    }

    private void Start()
    {
        gameInput.AddEnterPressedListener(OnEnterPressed);
    }

    private void OnEnterPressed(object sender, EventArgs e)
    {
        switch (gameState)
        {
            case GameState.PREGAME:
                goToIntro();
                break;
            case GameState.INTRO:
                goToCountdown();
                break;
            case GameState.FINISHED:
                goToPregame();
                break;
        }
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.COUNTDOWN:
                // When the countdown is finished, we go into the running state
                break;
            case GameState.RUNNING:
                // When the game is finished, we go into the finished state
                break;
        }
    }

    private void goToIntro()
    {
        gameState = GameState.INTRO;    
        fireStateChangeEvent();
    }
    
    private void goToCountdown()
    {
        gameState = GameState.COUNTDOWN;
        fireStateChangeEvent();
    }
    
    private void goToPregame()
    {
        gameState = GameState.PREGAME;
        fireStateChangeEvent();
    }

    private void fireStateChangeEvent()
    {
        Debug.Log("Game State is now: " + gameState);
        OnStateChange?.Invoke(this, EventArgs.Empty);
    }
}