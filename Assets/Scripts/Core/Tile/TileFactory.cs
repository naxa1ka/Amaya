using UnityEngine;

public class TileFactory : MonoBehaviour
{
    [SerializeField] private Tile _prefab;

    public Tile GetTile()
    {
        return Instantiate(_prefab);
    }

    public Tile GetTile(Vector3 position, Quaternion rotation, Transform parent = null)
    {
        return Instantiate(_prefab, position, rotation, parent);
    }

    public Tile GetTile(CardData cardData, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        var tile = GetTile(position, rotation, parent);
        tile.Init(cardData);
        
        return tile;
    }
}