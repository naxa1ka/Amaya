using UnityEngine;

public class LevelAnswer : MonoBehaviour
{
    [SerializeField] private LevelAnswerView _levelAnswerView;
    
    private string _identifier;

    public void Init(string identifier)
    {
        _identifier = identifier;
        _levelAnswerView.Init(identifier);
    }

    public bool IsCorrectlyAnswer(string identifier)
    {
        return identifier == _identifier;
    }
}