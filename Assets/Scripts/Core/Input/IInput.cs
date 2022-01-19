    using System;
    using UnityEngine;

    public interface IInput
    {
        event Action<Vector3> Clicked;
        bool IsEnabled { get; set; }
    }
