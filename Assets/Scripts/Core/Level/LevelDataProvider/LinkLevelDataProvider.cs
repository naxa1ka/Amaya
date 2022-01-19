using System.Collections.Generic;
using UnityEngine;

public class LinkLevelDataProvider : MonoBehaviour, ILevelDataProvider
{
    [SerializeField] private List<LevelData> _levelsData;
    
    public IReadOnlyList<LevelData> LevelData => _levelsData;
}