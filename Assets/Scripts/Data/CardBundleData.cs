using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardBundleData", menuName = "CardBundleData", order = 0)]
public class CardBundleData : ScriptableObject
{
    [SerializeField] private CardData[] _cardData;
    public IReadOnlyList<CardData> CardData => _cardData;
}