using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private bool isCountingDown;
    
    private void Start()
    {
        gameObject.SetActive(false);
        FullGameManager.Instance.OnStateChange += OnStateChange;
    }
    
    private void Update()
    {
        if (isCountingDown)
        {
            text.text = FullGameManager.Instance.GetCountdownTime().ToString();
        }
    }
    
    private void OnStateChange(object sender, System.EventArgs e)
    {
        switch (FullGameManager.Instance.gameState)
        {
            case GameState.COUNTDOWN:
                Show();
                break;
            default:
                Hide();
                break;
        }
    }
    
    private void Show()
    {
        isCountingDown = true;
        gameObject.SetActive(true);
    }
    
    private void Hide()
    {
        isCountingDown = false;
        gameObject.SetActive(false);
    }
}
