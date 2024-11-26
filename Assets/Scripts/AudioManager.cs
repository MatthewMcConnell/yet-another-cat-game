using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource introOutroBackground;
    [SerializeField] private AudioSource mainBackground;
    [SerializeField] private AudioSource introVoice;
    [SerializeField] private AudioSource winVoice;
    [SerializeField] private AudioSource loseVoice;
    
    private void Start()
    {
        introOutroBackground.Play();
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }

    private void OnStateChange(object sender, EventArgs e)
    {
        switch (FullGameManager.Instance.gameState)
        {
            case GameState.PREGAME:
                winVoice.Stop();
                loseVoice.Stop();
                introOutroBackground.Play();
                break;
            case GameState.INTRO:
                introVoice.Play();
                break;
            case GameState.COUNTDOWN:
                introVoice.Stop();
                introOutroBackground.Stop();
                mainBackground.Play();
                break;
            case GameState.FINISHED:
                mainBackground.Stop();
                introOutroBackground.Play();
                playEndVoice();
                break;
        }
    }

    private void playEndVoice()
    {
        if (FullGameManager.Instance.hasPlayerWon) winVoice.Play();
        else loseVoice.Play();
    }
}
