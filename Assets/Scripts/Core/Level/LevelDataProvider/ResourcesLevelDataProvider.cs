using System.Collections.Generic;
using UnityEngine;

public class ResourcesLevelDataProvider : MonoBehaviour, ILevelDataProvider
{
    private LevelData[] _levelDatas;

    public IReadOnlyList<LevelData> LevelData
    {
        get
        {
            if (_levelDatas == null)
            {
                _levelDatas = Resources.FindObjectsOfTypeAll<LevelData>();
            }

            return _levelDatas;
        }
    }
}