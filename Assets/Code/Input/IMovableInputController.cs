using System;
using UnityEngine;

namespace Code.Input
{
    public interface IMovableInputController
    {
        public event Action<float, float> OnMove;
        public event Action<bool> OnMovePressed;
        public event Action OnFirePressed;
        public void Update();
        public void Init();
        public void Start();
        public void Disable();
    }
}