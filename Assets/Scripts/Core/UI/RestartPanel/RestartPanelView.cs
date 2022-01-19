using System;
using UnityEngine;
using UnityEngine.UI;


public class RestartPanelView : Window
{
    [SerializeField] private Button _restartButton;

    public event Action RestartClicked;
    
    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        RestartClicked?.Invoke();
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);
    }
}