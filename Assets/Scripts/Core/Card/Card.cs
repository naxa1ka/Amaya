using UnityEngine;

[RequireComponent(typeof(CardView))]
public class Card : MonoBehaviour
{
    private string _identifier;
    private CardView _cardView;
    
    public string Identifier => _identifier;
    public float CorrectlyAnswerAnimationDuration => _cardView.CorrectlyAnswerAnimation;
    public float AppearanceAnimationDuration => _cardView.AppearanceAnimationDuration;

    public void Init(CardData cardData)
    {
        _identifier = cardData.Identifier;

        _cardView.Init(cardData);
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

    private void Awake()
    {
        _cardView = GetComponent<CardView>();
    }
}