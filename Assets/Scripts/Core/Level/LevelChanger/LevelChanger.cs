using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private LevelChangerView _levelChangerView;
    [Space] 
    [SerializeField] private GameFieldInstaller _gameFieldInstaller;
    [SerializeField] private LevelAnswerInstaller _levelAnswerInstaller;

    private ILevelDataProvider _dataProvider;
    private IInput _input;

    private IReadOnlyList<LevelData> _levelsData;
    private int _currentLevel;

    [Inject]
    private void Constructor(IInput input, ILevelDataProvider levelDataProvider)
    {
        _dataProvider = levelDataProvider;
    }
    
    public void LoadFirstLevel()
    {
        _currentLevel = 0;
        Load();
        AnimateLoad();
    }

    public bool MoveNextLevel()
    {
        if (_currentLevel == _levelsData.Count) return false;

        Load();
        return true;
    }

    private async void AnimateLoad()
    {
        await _levelChangerView.Init();
    }

    private void Load()
    {
        if (_levelsData == null)
        {
            _levelsData = _dataProvider.LevelData;
        }

        Init(_levelsData[_currentLevel]);
        
        _currentLevel++;
    }

    public void Dispose()
    {
        _levelAnswerInstaller.Dispose();
        _levelChangerView.Dispose();
    }

    private void Init(LevelData levelData)
    {
        _gameFieldInstaller.Init(levelData);
        _levelAnswerInstaller.Init(levelData);
    }
}