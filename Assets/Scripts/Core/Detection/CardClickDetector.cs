using System;
using UnityEngine;
using UnityEngine.Events;

public class CardClickDetector : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _input;
    [SerializeField] private CardEvent _clicked;

    private Camera _camera;
    private IInput Input => (IInput) _input;
    
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
            if (hit.collider.TryGetComponent<Card>(out var tile))
            {
                _clicked?.Invoke(tile);
            }
        }
    }
    
    private void OnDisable()
    {
        Input.Clicked -= OnClick;
    }
}

[Serializable]

public class CardEvent : UnityEvent <Card> {}