using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 0)]
public class LevelData : ScriptableObject
{
    [SerializeField] private CardBundleData[] _cardBundleData;
    public IReadOnlyList<CardBundleData> CardBundleData => _cardBundleData;

    public CardData this[int row, int column] => _cardBundleData[row].CardData[column];
}