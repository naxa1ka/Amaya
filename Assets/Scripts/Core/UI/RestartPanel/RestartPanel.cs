using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class RestartPanel : MonoBehaviour
{
    [SerializeField] private RestartPanelView _restartPanelView;
    [SerializeField] private SceneLoaderView _sceneLoaderView;
    [SerializeField] private LevelChanger _levelChanger;

    private IInput _input;

    [Inject]
    private void Constructor(IInput input)
    {
        _input = input;
    }

    public void Open()
    {
        _restartPanelView.FadeIn();
        _input.IsEnabled = false;
    }

    private void OnEnable()
    {
        _restartPanelView.RestartClicked += OnRestartClicked;
    }

    private async void OnRestartClicked()
    {
        _restartPanelView.FadeOut();
        
        await Hide();

        await Show();
    }

    private async Task Show()
    {
        _sceneLoaderView.FadeOut();
        await Task.Delay(TimeSpan.FromSeconds(_sceneLoaderView.Duration));
        _levelChanger.LoadFirstLevel();
    }

    private async Task Hide()
    {
        _sceneLoaderView.FadeIn();
        await Task.Delay(TimeSpan.FromSeconds(_sceneLoaderView.Duration));
        _levelChanger.Dispose();
    }

    private void OnDisable()
    {
        _restartPanelView.RestartClicked -= OnRestartClicked;
    }
}