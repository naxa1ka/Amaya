using UnityEngine;

[RequireComponent(typeof(CardView))]
public class Card : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _content;

    private string _identifier;
    private CardView _cardView;
    
    public string Identifier => _identifier;

    public float CorrectlyAnswerAnimationDuration => _cardView.CorrectlyAnswerAnimation;
    public float AppearanceAnimationDuration => _cardView.AppearanceAnimationDuration;
    
    private void Awake()
    {
        _cardView = GetComponent<CardView>();
    }

    public void Init(CardData cardData)
    {
        _identifier = cardData.Identifier;
        _content.sprite = cardData.Sprite;
        
        _cardView.Init(_content.gameObject);
    }

    public void Hide()
    {
        transform.localScale = Vector3.zero;
    }
    
    public void PlayWrongAnswerAnimation()
    {
        _cardView.PlayWrongAnswerAnimation();
    }

    public void PlayCorrectlyAnswerAnimation()
    {
        _cardView.PlayCorrectlyAnswerAnimation();        
    }

    public void PlayAppearanceAnimation()
    {
        _cardView.PlayAppearanceAnimation(gameObject);
    }
}