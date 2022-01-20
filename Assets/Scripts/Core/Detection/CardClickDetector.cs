using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CardClickDetector : MonoBehaviour
{
    [SerializeField] private CardEvent _clicked;

    private Camera _camera;
    private IInput _input;

    [Inject]
    private void Constructor(Camera cam, IInput input)
    {
        _camera = cam;
        _input = input;
    }
    
    private void OnEnable()
    {
        _input.Clicked += OnClick;
    }

    private void OnClick(Vector3 position)
    {
        var worldPosition = _camera.ScreenToWorldPoint(position);
        var hit = Physics2D.Raycast(worldPosition, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<Card>(out var tile))
            {
                _clicked?.Invoke(tile);
            }
        }
    }
    
    private void OnDisable()
    {
        _input.Clicked -= OnClick;
    }
}

[Serializable]

public class CardEvent : UnityEvent <Card> {}