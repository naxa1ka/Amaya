using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameFieldSpawner : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GameField _gameField;
    [SerializeField] private CardFactory _cardFactory;
    
    private List<Card> _spawnedTiles;

    public List<Card> Init(LevelData levelData)
    {
        Dispose();
        
        _spawnedTiles = new List<Card>();
        
        var levelDataCardBundleData = levelData.CardBundleData;

        int maxY = levelDataCardBundleData.Count;
        int maxX = levelDataCardBundleData.Select(cardBundleData => cardBundleData.CardData.Count).Max();
        
        _gameField.Init(maxX, maxY);

        SpawnTiles(levelData, maxX);

        return _spawnedTiles;
    }

    private void Dispose()
    {
        if(_spawnedTiles == null) return;

        foreach (var spawnedTile in _spawnedTiles)
        {
            Destroy(spawnedTile.gameObject);
        }
    }

    private void SpawnTiles(LevelData levelData, int maxX)
    {
        var x = 0;
        var y = 0;
        
        using (var enumerator = levelData.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                if (x == maxX)
                {
                    x = 0;
                    y++;
                }

                var cardData = enumerator.Current;

                var centerOfCell = _gameField.GetCenterOfCell(x, y);

                var card = _cardFactory.GetCard(cardData, centerOfCell, Quaternion.identity, _parent);
                _spawnedTiles.Add(card);
                
                x++;
            }  
        }
    }
}