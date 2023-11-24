using System;
using UnityEngine.InputSystem;

namespace Code.Input.Keyboard
{
    public class KeyboardInputController : IMovableInputController
    {
        private GamePlayerInput _gamePlayerInput;
        public event Action<float, float> OnMove;
        public event Action<bool> OnMovePressed;
        public event Action OnFirePressed;

        public void Update()
        {
            var rotation = _gamePlayerInput.Player.Rotate.ReadValue<float>();
            var movement = _gamePlayerInput.Player.Move.ReadValue<float>();
            
            OnMove?.Invoke(movement, rotation);
            
            OnMovePressed?.Invoke(_gamePlayerInput.Player.enabled);
        }

        public void Init()
        {
            _gamePlayerInput = new GamePlayerInput();
            _gamePlayerInput.Enable();
        }

        public void Start()
        {
            
        }

        public void Disable()
        {
            _gamePlayerInput.Disable();
        }
    }
}