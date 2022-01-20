using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 0)]
public class LevelData : ScriptableObject, IEnumerable<CardData>
{
    [SerializeField] private CardBundleData[] _cardBundleData;
    public IReadOnlyList<CardBundleData> CardBundleData => _cardBundleData;
    
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