using System.Collections;
using UnityEngine;

public class SceneLoaderView : Window
{
    public void Open(AsyncOperation asyncOperation)
    {
        FadeIn();
        StartCoroutine(AsyncLoadSceneRoutine(asyncOperation));
        FadeOut();
    }

    private IEnumerator AsyncLoadSceneRoutine(AsyncOperation asyncOperation)
    {
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}