using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameFieldView : MonoBehaviour
{
    private List<Card> _tiles;

    public void Init(List<Card> tiles)
    {
        _tiles = tiles;
    }

    public void Hide()
    {
        foreach (var tile in _tiles)
        {
            tile.Hide();
        }
    }

    public async Task PlayAppearanceAnimation()
    {
        foreach (var tile in _tiles)
        {
            tile.PlayAppearanceAnimation();
            await Task.Delay(TimeSpan.FromSeconds(tile.AppearanceAnimationDuration));
        }
    }
}