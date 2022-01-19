using System;
using System.Threading.Tasks;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private TileClickHandler _tileClick;
    [SerializeField] private RestartPanel _restartPanel;
    private void OnEnable()
    {
        _tileClick.CorrectlyAnswerClicked += OnCorrectlyAnswerClicked;
    }

    private async void OnCorrectlyAnswerClicked(Tile tile)
    {
        await Task.Delay(TimeSpan.FromSeconds(tile.CorrectlyAnswerAnimationDuration));
        
        if (_levelChanger.MoveNextLevel() == false)
        {
            _restartPanel.Open();
        }
    }

    private void Start()
    {
        _levelChanger.LoadFirstLevel();
    }
    private void OnDisable()
    {
        _tileClick.CorrectlyAnswerClicked -= OnCorrectlyAnswerClicked;
    }
}