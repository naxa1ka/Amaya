using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameFieldView : MonoBehaviour
{
    private List<Card> _cards;

    public void Init(List<Card> cards)
    {
        _cards = cards;
    }

    public async Task Show()
    {
        foreach (var card in _cards)
        {
            var cardView = card.CardView;
            
            cardView.PlayAppearanceAnimation();
            await Task.Delay(TimeSpan.FromSeconds(cardView.AppearanceAnimationDuration));
        }
    }

    public void Hide()
    {
        foreach (var card in _cards)
        {
            card.CardView.Hide();
        }
    }
}