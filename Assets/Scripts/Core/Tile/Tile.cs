using UnityEngine;

[RequireComponent(typeof(TileAnimation))]
public class Tile : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _content;

    private string _identifier;
    private TileAnimation _tileAnimation;
    
    public string Identifier => _identifier;

    public float CorrectlyAnswerAnimationDuration => _tileAnimation.CorrectlyAnswerAnimation;
    public float AppearanceAnimationDuration => _tileAnimation.AppearanceAnimationDuration;
    
    private void Awake()
    {
        _tileAnimation = GetComponent<TileAnimation>();
    }

    public void Init(CardData cardData)
    {
        _identifier = cardData.Identifier;
        _content.sprite = cardData.Sprite;
        
        _tileAnimation.Init(_content.gameObject);
    }

    public void Hide()
    {
        transform.localScale = Vector3.zero;
    }
    
    public void PlayWrongAnswerAnimation()
    {
        _tileAnimation.PlayWrongAnswerAnimation();
    }

    public void PlayCorrectlyAnswerAnimation()
    {
        _tileAnimation.PlayCorrectlyAnswerAnimation();        
    }

    public void PlayAppearanceAnimation()
    {
        _tileAnimation.PlayAppearanceAnimation(gameObject);
    }
}