using UnityEngine;

[RequireComponent(typeof(CardView))]
public class Card : MonoBehaviour
{
    private string _identifier;
    private CardView _cardView;

    public string Identifier => _identifier;
    public CardView CardView => _cardView;

    public void Init(CardData cardData)
    {
        _identifier = cardData.Identifier;

        _cardView.Init(cardData);
    }

    private void Awake()
    {
        _cardView = GetComponent<CardView>();
    }
}