using System;
using UnityEngine;

public class TileClickDetector : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _input;

    private Camera _camera;
    private IInput Input => (IInput) _input;

    public event Action<Tile> Clicked;
    
    private void OnValidate()
    {
        if (_input is IInput)
            return;

        Debug.LogError(_input.name + " needs to implement " + nameof(IInput));
        _input = null;
    }

    private void OnEnable()
    {
        Input.Clicked += OnClick;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnClick(Vector3 position)
    {
        var worldPosition = _camera.ScreenToWorldPoint(position);
        var hit = Physics2D.Raycast(worldPosition, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<Tile>(out var tile))
            {
                Clicked?.Invoke(tile);
            }
        }
    }
    private void OnDisable()
    {
        Input.Clicked -= OnClick;
    }
}