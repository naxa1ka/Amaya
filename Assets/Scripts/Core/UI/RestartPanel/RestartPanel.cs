using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    [SerializeField] private RestartPanelView _restartPanelView;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private MonoBehaviour _input;
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

    private void OnRestartClicked()
    {
        _restartPanelView.FadeOut();
        _sceneLoader.LoadMainScene();
    }

    private void OnDisable()
    {
        _restartPanelView.RestartClicked += OnRestartClicked;
    }
}