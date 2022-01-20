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
    [Header("Wrong settings")]
    [SerializeField] private int _vibrationWrong;
    [SerializeField] private ScaleSettings _wrongSettings;
    [Header("Correctly settings")]
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _delaySpawnParticles;
    [SerializeField] private ScaleSettings _correctlySettings;
    [Header("Appearance settings")]
    [SerializeField] private ScaleSettings _appearanceSettings;

    private Vector3 _initialScale;
    private GameObject _target;
    
    public float CorrectlyAnswerAnimation => _correctlySettings.Duration + _particleSystem.main.duration;
    public float AppearanceAnimationDuration => _appearanceSettings.Duration;

    public void Init(GameObject target)
    {
        _target = target;
        _initialScale = target.transform.localScale;
    }

    public void PlayWrongAnswerAnimation()
    {
        var settings = _wrongSettings;
        
        _target.transform.DORewind(false);

        _target.transform
            .DOShakePosition(settings.Duration, settings.Strength, _vibrationWrong, 0)
            .SetEase(settings.Ease);
    }

    public void PlayCorrectlyAnswerAnimation()
    {
        var settings = _correctlySettings;
        
        _target.transform
            .DOScale(settings.Strength, settings.Duration)
            .SetEase(settings.Ease)
            .OnComplete(
                () => _target.transform.DOScale(_initialScale, settings.Duration)
            );

        this.DelayAction(
            () => Instantiate(_particleSystem, transform.position, quaternion.identity),
            _delaySpawnParticles
        );
    }

    public void PlayAppearanceAnimation(GameObject target)
    {
        var settings = _appearanceSettings;
        
        target.transform
            .DOScale(settings.Strength, settings.Duration)
            .SetEase(settings.Ease);
    }
}