using System;
using DG.Tweening;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeDuration = 0.25f;

    private void Start()
    {
        Reset();
    }

    public void FadeOut()
    {
        Reset();
        _canvasGroup.DOFade(0f, _fadeDuration);
    }

    private void Reset()
    {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void FadeIn()
    {
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.DOFade(1f, _fadeDuration);
    }
}