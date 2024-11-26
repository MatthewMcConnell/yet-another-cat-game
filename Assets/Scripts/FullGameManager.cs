using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullGameManager : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private float countdownDurationInSeconds;
    [SerializeField] private float gameDurationInSeconds;
    [SerializeField] private float delayToFinishInSeconds;
    [SerializeField] private List<Monster> monsters;

    public static FullGameManager Instance { get; private set; }
    public GameState gameState { get; private set; }
    public bool hasPlayerWon { get; private set; }
    public event EventHandler OnStateChange;

    private float countdownTimer;
    private float gameTimer;
    private float delayToFinishTimer;
    private int monstersAlive;

    private void Awake()
    {
        Instance = this;
        gameState = GameState.PREGAME;
        hasPlayerWon = false;
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
                processCountdown();
                break;
            case GameState.RUNNING:
                processRunning();
                break;
        }
    }

    private void processRunning()
    {
        if (!hasPlayerWon)
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0)
            {
                hasPlayerWon = false;
                goToFinished();
            }

            if (AllMonstersAreDead())
            {
                hasPlayerWon = true;
                delayToFinishTimer = delayToFinishInSeconds;
            }
        }
        else
        {
            delayToFinishTimer -= Time.deltaTime;
            if (delayToFinishTimer <= 0)
            {
                goToFinished();
            }
        }
    }

    private bool AllMonstersAreDead()
    {
        return monstersAlive == 0;
    }

    private void goToFinished()
    {
        gameState = GameState.FINISHED;
        fireStateChangeEvent();
    }

    private void processCountdown()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0)
        {
            goToRunning();
        }
    }

    private void goToRunning()
    {
        foreach (var monster in monsters)
        {
            monster.Spawn();
        }

        hasPlayerWon = false;
        monstersAlive = monsters.Count;
        gameTimer = gameDurationInSeconds;
        gameState = GameState.RUNNING;
        fireStateChangeEvent();
    }

    private void goToIntro()
    {
        gameState = GameState.INTRO;
        fireStateChangeEvent();
    }

    private void goToCountdown()
    {
        countdownTimer = countdownDurationInSeconds;
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
        OnStateChange?.Invoke(this, EventArgs.Empty);
    }

    public int GetCountdownTime()
    {
        return Mathf.CeilToInt(countdownTimer);
    }

    public float GetGameTime()
    {
        return 1 - gameTimer / gameDurationInSeconds;
    }

    public void OnMonsterDied()
    {
        monstersAlive--;
    }

    public int GetMonstersLeft()
    {
        return monstersAlive;
    }
}