using System;
using UnityEngine;

[Serializable]
public class CardData 
{
    [SerializeField] private string _identifier;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Color _backgroundColor;
    public string Identifier => _identifier;
    public Sprite Sprite => _sprite;
    public Color BackgroundColor => _backgroundColor;
}