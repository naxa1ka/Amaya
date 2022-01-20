using System.Threading.Tasks;
using UnityEngine;

public class LevelChangerView : MonoBehaviour
{
    [SerializeField] private LevelAnswerView _levelAnswerView;
    [SerializeField] private GameFieldView _gameFieldView;

    public async Task Init()
    {
        Dispose();
        
        await _gameFieldView.PlayAppearanceAnimation();
        await _levelAnswerView.FadeIn();
    }

    public void Dispose()
    {
        _levelAnswerView.Hide();
        _gameFieldView.Hide();
    }
}