using DG.Tweening;
using UnityEngine;

public class TileAnimation : MonoBehaviour
{
    [Header("Wrong animations")] 
    [SerializeField] private float _durationWrong = 0.25f;
    [SerializeField] private float _strengthWrong = 1f;
    [SerializeField] private int _vibratoWrong = 10;
    [SerializeField] private Ease _easeWrong = Ease.InBounce;

    [Header("Correctly animations")] 
    [SerializeField] private float _durationCorrectly = 0.25f;
    [SerializeField] private Vector3 _scaleCorrectly = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] private Ease _easeCorrectly = Ease.InBounce;
    private Vector3 _initialScale;
    
    private GameObject _target;

    public float CorrectlyAnswerAnimation => _durationCorrectly;
    public float AppearanceAnimationDuration => _durationCorrectly;

    public void Init(GameObject target)
    {
        _target = target;
        _initialScale = target.transform.localScale;
    }

    public void PlayWrongAnswerAnimation()
    {
        _target.transform.DORewind(false);
        
        _target.transform
            .DOShakePosition(_durationWrong, _strengthWrong, _vibratoWrong)
            .SetEase(_easeWrong);
    }

    public float PlayCorrectlyAnswerAnimation()
    {
        _target.transform
            .DOScale(_scaleCorrectly, _durationCorrectly)
            .SetEase(_easeCorrectly)
            .OnComplete(
                () => _target.transform.DOScale(_initialScale, _durationCorrectly)
            );
        return _durationCorrectly * 2;
    }

    public float PlayAppearanceAnimation(GameObject target)
    {
        target.transform
            .DOScale(_scaleCorrectly, _durationCorrectly)
            .SetEase(_easeCorrectly)
            .OnComplete(
                () => _target.transform.DOScale(_initialScale, _durationCorrectly)
            );

        return _durationCorrectly;
    }
}