using System;
using UnityEngine;

public class CardClickHandler : MonoBehaviour
{
    [SerializeField] private LevelAnswer _levelAnswer;

    public event Action<Card> CorrectlyAnswerClicked;

    public void OnClicked(Card card)
    {
        var isCorrectlyAnswer = _levelAnswer.IsCorrectlyAnswer(card.Identifier);
        if (isCorrectlyAnswer)
        {
            card.PlayCorrectlyAnswerAnimation();
            CorrectlyAnswerClicked?.Invoke(card);
        }
        else
        {
            card.PlayWrongAnswerAnimation();
        }
    }
}