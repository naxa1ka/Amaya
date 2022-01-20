using System;
using System.Threading.Tasks;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    [SerializeField] private RestartPanelView _restartPanelView;
    [SerializeField] private SceneLoaderView _sceneLoaderView;
    [SerializeField] private MonoBehaviour _input;
    [SerializeField] private GameCycle _gameCycle;
    
    private IInput Input => (IInput)_input;
    
    public void Open()
    {
        _restartPanelView.FadeIn();
        Input.IsEnabled = false;
    }

    private void OnValidate()
    {
        if (_input is IInput == false)
        {
            Debug.LogError(_input.name + " needs to implement " + nameof(IInput));
            _input = null;
        }
    }

    private void OnEnable()
    {
        _restartPanelView.RestartClicked += OnRestartClicked;
    }

    private async void OnRestartClicked()
    {
        _restartPanelView.FadeOut();
        
        _sceneLoaderView.FadeIn();
        await Task.Delay(TimeSpan.FromSeconds(_sceneLoaderView.Duration));
        _gameCycle.OnRestartStarted();
        
        _sceneLoaderView.FadeOut();
        await Task.Delay(TimeSpan.FromSeconds(_sceneLoaderView.Duration));
        _gameCycle.OnRestartEnded();
    }

    private void OnDisable()
    {
        _restartPanelView.RestartClicked -= OnRestartClicked;
    }
}