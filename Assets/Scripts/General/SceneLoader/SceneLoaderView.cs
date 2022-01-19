using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderView : Window
{
    [SerializeField] private Slider _loadingSlider;
    [SerializeField] private TextMeshProUGUI _progressText;

    private const float ValueIsLoadingCompleted = 0.9f;

    public void Open(AsyncOperation asyncOperation)
    {
        FadeIn();
        StartCoroutine(AsyncLoadSceneRoutine(asyncOperation));
    }

    private IEnumerator AsyncLoadSceneRoutine(AsyncOperation asyncOperation)
    {
        while (!asyncOperation.isDone)
        {
            float normalizedProgress = asyncOperation.progress / ValueIsLoadingCompleted;

            _loadingSlider.value = normalizedProgress;

            _progressText.text = string.Format($"{normalizedProgress * 100:0}%");

            yield return null;
        }
    }
}