using System;
using System.Threading.Tasks;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private CardClickHandler _cardClick;
    [SerializeField] private RestartPanel _restartPanel;
    [SerializeField] private MonoBehaviour _input;
    
    private IInput Input => (IInput) _input;
    
    private void OnValidate()
    {
        if (_input is IInput)
            return;

        Debug.LogError(_input.name + " needs to implement " + nameof(IInput));
        _input = null;
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
        Input.IsEnabled = false;
        await Task.Delay(TimeSpan.FromSeconds(card.CardView.CorrectlyAnswerAnimationDuration));
        Input.IsEnabled = true;
        
        if (_levelChanger.MoveNextLevel() == false)
        {
            _restartPanel.Open();
        }
    }

    private void OnDisable()
    {
        _cardClick.CorrectlyAnswerClicked -= OnCorrectlyAnswerClicked;
    }
}