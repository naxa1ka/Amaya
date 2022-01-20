using System;
using System.Collections;
using UnityEngine;

public static class MonoBehaviourExtension
{
    public static void DelayAction(this MonoBehaviour monoBehaviour, Action action, float delay)
    {
        monoBehaviour.StartCoroutine(DelayActionRoutine(action, delay));
    }

    private static IEnumerator DelayActionRoutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}