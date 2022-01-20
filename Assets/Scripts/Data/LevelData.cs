using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 0)]
public class LevelData : ScriptableObject, IEnumerable<CardData>
{
    [SerializeField] private CardBundleData[] _cardBundleData;

    public int SizeY => _cardBundleData.Length;
    public int SizeX => _cardBundleData.Select(cardBundleData => cardBundleData.CardData.Count).Min();

    public IEnumerator<CardData> GetEnumerator()
    {
        foreach (var cardBundleData in _cardBundleData)
        {
            foreach (var cardData in cardBundleData.CardData)
            {
                yield return cardData;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}