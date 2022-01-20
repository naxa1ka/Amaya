using System;
using UnityEngine;
using Zenject;

public class DesktopInput : IInput, ITickable
{
    private const int LeftKeyMouse = 0;

    public event Action<Vector3> Clicked;
    public bool IsEnabled { get; set; }
    
    public void Tick()
    {
        if (IsEnabled == false) return;
        
        if (Input.GetMouseButtonDown(LeftKeyMouse))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}