using System;
using UnityEngine;

namespace Code.Input.Keyboard
{
    public class KeyboardInputController : IMovableInputController
    {
        private GamePlayerInput _gamePlayerInput;
        public event Action<float, float> OnMove;
        public event Action<bool> OnMovePressed;
        public event Action<bool> OnFirePressed;
        public event Action<bool> OnLeftWeaponSelected;
        public event Action<bool> OnRightWeaponSelected;

        public void Update()
        {
            var rotation = _gamePlayerInput.Player.Rotate.ReadValue<float>();
            var movement = _gamePlayerInput.Player.Move.ReadValue<float>();

            OnMovePressed?.Invoke(true);

            OnMove?.Invoke(movement, rotation);
        }

        public void Init()
        {
            _gamePlayerInput = new GamePlayerInput();
            _gamePlayerInput.Enable();
            
            _gamePlayerInput.Player.Fire.started += ( context ) => OnFirePressed?.Invoke(context.started);
            _gamePlayerInput.Player.SwitchLeft.started += ( context ) => OnLeftWeaponSelected?.Invoke(context.started);
            _gamePlayerInput.Player.SwitchRight.started += ( context ) => OnRightWeaponSelected?.Invoke(context.started);
        }

        public void Disable()
        {
            _gamePlayerInput.Disable();
        }
    }
}