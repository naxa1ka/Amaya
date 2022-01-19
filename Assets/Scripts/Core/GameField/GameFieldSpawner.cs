using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameFieldSpawner : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GameField _gameField;
    [SerializeField] private TileFactory _tileFactory;
    
    private List<Tile> _spawnedTiles;

    public List<Tile> Init(LevelData levelData)
    {
        TryDispose();
        
        _spawnedTiles = new List<Tile>();
        
        var levelDataCardBundleData = levelData.CardBundleData;

        int maxY = levelDataCardBundleData.Count;
        int maxX = levelDataCardBundleData.Select(cardBundleData => cardBundleData.CardData.Count).Max();
        
        _gameField.Init(maxX, maxY);

        SpawnTiles(levelData, maxX, maxY);

        return _spawnedTiles;
    }

    private void TryDispose()
    {
        if(_spawnedTiles == null) return;

        foreach (var spawnedTile in _spawnedTiles)
        {
            Destroy(spawnedTile.gameObject);
        }
    }
    
    private void SpawnTiles(LevelData levelData, int maxX, int maxY)
    {
        for (int row = 0; row < maxX; row++)
        {
            for (int column = 0; column < maxY; column++)
            {
                var centerOfCell = _gameField.GetCenterOfCell(column, row);

                var tile = _tileFactory.GetTile(levelData[row, column], centerOfCell, Quaternion.identity, _parent);
                _spawnedTiles.Add(tile);
            }
        }
    }
}