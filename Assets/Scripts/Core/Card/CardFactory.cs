using UnityEngine;

public class CardFactory : MonoBehaviour
{
    [SerializeField] private Card _prefab;

    public Card GetCard()
    {
        return Instantiate(_prefab);
    }

    public Card GetCard(Vector3 position, Quaternion rotation, Transform parent = null)
    {
        return Instantiate(_prefab, position, rotation, parent);
    }

    public Card GetCard(CardData cardData, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        var tile = GetCard(position, rotation, parent);
        tile.Init(cardData);
        
        return tile;
    }
}