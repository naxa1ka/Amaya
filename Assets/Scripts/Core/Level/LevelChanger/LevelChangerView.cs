using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelChangerView : MonoBehaviour
{
    [SerializeField] private LevelAnswerView _levelAnswerView;
    [SerializeField] private GameFieldView _gameFieldView;
    
    private IInput _input;

    [Inject]
    private void Constructor(IInput input)
    {
        _input = input;
    }
    
    public async Task Init()
    {
        _input.IsEnabled = false;
        
        Dispose();
        
        await _gameFieldView.Show();
        await _levelAnswerView.Show();
        
        _input.IsEnabled = true;
    }

    public void Dispose()
    {
        _levelAnswerView.Hide();
        _gameFieldView.Hide();
    }
}