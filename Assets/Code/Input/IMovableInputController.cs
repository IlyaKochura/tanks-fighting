using System;
using UnityEngine;

namespace Code.Input
{
    public interface IMovableInputController
    {
        public event Action<float, float> OnMove;
        public event Action<bool> OnMovePressed;
        public event Action<bool> OnFirePressed;
        public event Action<bool> OnLeftWeaponSelected;
        public event Action<bool> OnRightWeaponSelected;
        public void Update();
        public void Init();
        public void Disable();
    }
}