using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneLoaderView _sceneLoaderView;

    public void LoadMainScene()
    {
        var loadSceneAsync = SceneManager.LoadSceneAsync((int)SceneId.MainScene);
        _sceneLoaderView.Open(loadSceneAsync);
    }
}