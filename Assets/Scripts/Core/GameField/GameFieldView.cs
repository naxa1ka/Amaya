using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameFieldView : MonoBehaviour
{
    private List<Tile> _tiles;

    public void Init(List<Tile> tiles)
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