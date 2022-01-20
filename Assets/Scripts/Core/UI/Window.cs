using DG.Tweening;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeDuration = 0.25f;

    public float Duration => _fadeDuration;
    
    public void FadeOut()
    {
        LockPanel();

        Fade(0f);
    }

    public void FadeIn()
    {
        UnlockPanel();

        Fade(1f);
    }

    private void Start()
    {
        LockPanel();
    }

    private void Fade(float endValue)
    {
        _canvasGroup.DOFade(endValue, _fadeDuration);
    }

    private void LockPanel()
    {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void UnlockPanel()
    {
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
}