using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private LevelChangerView _levelChangerView;
    [Space]
    [SerializeField] private GameFieldInstaller _gameFieldInstaller;
    [SerializeField] private LevelAnswerInstaller _levelAnswerInstaller;
    [Space]
    [SerializeField] private MonoBehaviour _dataProvider;
    [SerializeField] private MonoBehaviour _input;
    
    private IInput Input => (IInput) _input;
    private ILevelDataProvider DataProvider => (ILevelDataProvider)_dataProvider;

    private IReadOnlyList<LevelData> _levelsData;
    private int _currentLevel;

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

    private void OnValidate()
    {
        if (_input is IInput == false)
        {
            Debug.LogError(_input.name + " needs to implement " + nameof(IInput));
            _input = null;
        }
        
        if (_dataProvider is ILevelDataProvider == false)
        {
            Debug.LogError(_dataProvider.name + " needs to implement " + nameof(ILevelDataProvider));
            _dataProvider = null;
        }
    }

    private async void AnimateLoad()
    {
        Input.IsEnabled = false;
        await _levelChangerView.Init();
        Input.IsEnabled = true;
    }

    private void Load()
    {
        if (_levelsData == null)
        {
            _levelsData = DataProvider.LevelData;
        }

        var levelData = _levelsData[_currentLevel];
        _currentLevel++;
        
        Init(levelData);
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