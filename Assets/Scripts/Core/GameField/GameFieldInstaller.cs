using UnityEngine;

public class GameFieldInstaller : MonoBehaviour
{
    [SerializeField] private GameFieldSpawner _gameFieldSpawner;
    [SerializeField] private GameFieldView _gameFieldView;

    public void Init(LevelData levelData)
    {
        var cards = _gameFieldSpawner.Init(levelData);
        _gameFieldView.Init(cards);
    }
}