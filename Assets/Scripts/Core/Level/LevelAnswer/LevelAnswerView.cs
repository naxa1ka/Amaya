using System;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LevelAnswerView : MonoBehaviour
{
    [SerializeField] private float _fadeDuration;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private const string Template = "Find ";
    
    public void Init(string answer)
    {
        _textMeshProUGUI.text = $"{Template}{answer}";
    }

    public async Task Show()
    {
        _textMeshProUGUI.DOFade(1f, _fadeDuration);
        await Task.Delay(TimeSpan.FromSeconds(_fadeDuration));
    }

    public void Hide()
    {
        _textMeshProUGUI.alpha = 0f;
    }
}