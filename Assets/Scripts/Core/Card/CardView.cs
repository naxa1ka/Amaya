using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [Header("Correctly animations paricles")]
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _delaySpawnParticles;
    [Space] 
    [Header("Wrong animations")] 
    [SerializeField] private float _durationWrong = 0.25f;
    [SerializeField] private Vector3 _strengthWrong = new Vector3(1.2f, 0, 0);
    [SerializeField] private int _vibrationWrong;
    [SerializeField] private Ease _easeWrong = Ease.InBounce;
    [Space] 
    [Header("Correctly animations")]
    [SerializeField] private float _durationCorrectly = 0.25f;
    [SerializeField] private Vector3 _scaleCorrectly = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] private Ease _easeCorrectly = Ease.InBounce;
    [Space] 
    [Header("Appearance animations")] 
    [SerializeField] private float _appearanceDuration;
    [SerializeField] private Vector3 _appearanceScale = Vector3.one;
    [SerializeField] private Ease _appearanceEase;
    
    private Vector3 _initialScale;
    private GameObject _target;


    public float CorrectlyAnswerAnimation => _durationCorrectly + _particleSystem.main.duration;
    public float AppearanceAnimationDuration => _appearanceDuration;

    public void Init(GameObject target)
    {
        _target = target;
        _initialScale = target.transform.localScale;
    }

    public void PlayWrongAnswerAnimation()
    {
        _target.transform.DORewind(false);

        _target.transform
            .DOShakePosition(_durationWrong, _strengthWrong, _vibrationWrong)
            .SetEase(_easeWrong);
    }

    public void PlayCorrectlyAnswerAnimation()
    {
        _target.transform
            .DOScale(_scaleCorrectly, _durationCorrectly)
            .SetEase(_easeCorrectly)
            .OnComplete(
                () => _target.transform.DOScale(_initialScale, _durationCorrectly)
            );

        this.DelayAction(
            () => Instantiate(_particleSystem, transform.position, quaternion.identity),
            _delaySpawnParticles
        );
    }

    public void PlayAppearanceAnimation(GameObject target)
    {
        target.transform
            .DOScale(_appearanceScale, _appearanceDuration)
            .SetEase(_appearanceEase);
    }
}