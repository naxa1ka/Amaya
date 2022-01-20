using System;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public class ScaleSettings
{
    [SerializeField] private float _duration = 0.25f;
    [SerializeField] private Vector3 _strength = new Vector3(1f, 1f, 1f);
    [SerializeField] private Ease _ease = Ease.InBounce;
    
    public float Duration => _duration;
    public Vector3 Strength => _strength;
    public Ease Ease => _ease;
}

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _content;
    [SerializeField] private SpriteRenderer _background;
    [Header("Wrong settings")]
    [SerializeField] private int _vibrationWrong;
    [SerializeField] private ScaleSettings _wrongSettings;
    [Header("Correctly settings")]
    [SerializeField] private Vector3 _initialScale = Vector3.one;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _delaySpawnParticles;
    [SerializeField] private ScaleSettings _correctlySettings;
    [Header("Appearance settings")]
    [SerializeField] private ScaleSettings _appearanceSettings;
    
    public float CorrectlyAnswerAnimationDuration => _correctlySettings.Duration + _particleSystem.main.duration;
    public float AppearanceAnimationDuration => _appearanceSettings.Duration;
    
    private GameObject Target => _content.gameObject;

    public void Init(CardData cardData)
    {
        _content.sprite = cardData.Sprite;
        _background.color = cardData.BackgroundColor;
    }

    public void Hide()
    {
        gameObject.transform.localScale = Vector3.zero;
    }
    
    public void PlayWrongAnswerAnimation()
    {
        var settings = _wrongSettings;
        
        Target.transform.DORewind(false);

        Target.transform
            .DOShakePosition(settings.Duration, settings.Strength, _vibrationWrong, 0)
            .SetEase(settings.Ease);
    }

    public void PlayCorrectlyAnswerAnimation()
    {
        var settings = _correctlySettings;
        
        Target.transform
            .DOScale(settings.Strength, settings.Duration)
            .SetEase(settings.Ease)
            .OnComplete(
                () => Target.transform.DOScale(_initialScale, settings.Duration)
            );

        this.DelayAction(
            () => Instantiate(_particleSystem, transform.position, quaternion.identity),
            _delaySpawnParticles
        );
    }

    public void PlayAppearanceAnimation()
    {
        var settings = _appearanceSettings;
        
        gameObject.transform
            .DOScale(settings.Strength, settings.Duration)
            .SetEase(settings.Ease);
    }
}