using System;
using UnityEngine;

public class DesktopInput : MonoBehaviour, IInput
{
    private const int LeftKeyMouse = 0;

    public event Action<Vector3> Clicked;
    public bool IsEnabled { get; set; }

    private void Update()
    {
        if (IsEnabled == false) return;
        
        if (Input.GetMouseButtonDown(LeftKeyMouse))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}