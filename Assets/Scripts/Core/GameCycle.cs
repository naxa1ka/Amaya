using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameCycle : MonoBehaviour
{
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private CardClickHandler _cardClick;
    [SerializeField] private RestartPanel _restartPanel;

    private IInput _input;

    [Inject]
    private void Constructor(IInput input)
    {
        _input = input;
    }

    private void OnEnable()
    {
        _cardClick.CorrectlyAnswerClicked += OnCorrectlyAnswerClicked;
    }

    private void Start()
    {
        _levelChanger.LoadFirstLevel();
    }

    private async void OnCorrectlyAnswerClicked(Card card)
    {
        await WaitAnimation(card);

        if (_levelChanger.MoveNextLevel() == false)
        {
            _restartPanel.Open();
        }
    }

    private async Task WaitAnimation(Card card)
    {
        _input.IsEnabled = false;
        await Task.Delay(TimeSpan.FromSeconds(card.CardView.CorrectlyAnswerAnimationDuration));
        _input.IsEnabled = true;
    }

    private void OnDisable()
    {
        _cardClick.CorrectlyAnswerClicked -= OnCorrectlyAnswerClicked;
    }
}