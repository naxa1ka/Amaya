using System;
using UnityEngine;

public class TileClickHandler : MonoBehaviour
{
    [SerializeField] private TileClickDetector _clickDetector;
    [SerializeField] private LevelAnswer _levelAnswer;

    public event Action<Tile> CorrectlyAnswerClicked;

    private void OnEnable()
    {
        _clickDetector.Clicked += OnClicked;
    }

    private void OnClicked(Tile tile)
    {
        var isCorrectlyAnswer = _levelAnswer.IsCorrectlyAnswer(tile.Identifier);
        if (isCorrectlyAnswer)
        {
            tile.PlayCorrectlyAnswerAnimation();
            CorrectlyAnswerClicked?.Invoke(tile);
        }
        else
        {
            tile.PlayWrongAnswerAnimation();
        }
    }

    private void OnDisable()
    {
        _clickDetector.Clicked -= OnClicked;
    }
}