using System.Collections.Generic;
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

        var maxX =  levelData.SizeX;
        var maxY = levelData.SizeY;

        _gameField.Init(maxX, maxY);

        SpawnCards(levelData, maxX, maxY);

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

    private void SpawnCards(LevelData levelData, int maxX, int maxY)
    {
        for (int x = 0; x < maxX; x++)
        {
            for (int y = 0; y < maxY; y++)
            {
                Spawn(x, y, levelData[x,y]);
            }
        }
    }

    private void Spawn(int x, int y, CardData cardData)
    {
        var centerOfCell = _gameField.GetCenterOfCell(x, y);

        var card = _cardFactory.GetCard(centerOfCell, Quaternion.identity, _parent);
        card.Init(cardData);

        _spawnedTiles.Add(card);
    }
}