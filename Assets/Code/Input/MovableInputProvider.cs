using System;
using System.Collections.Generic;
using Code.Input.Keyboard;
using UnityEngine;

namespace Code.Input
{
    public class MovableInputProvider : MonoBehaviour
    {
        public Action<bool> OnMove { get; set; }

        private List<IMovableInputController> _movableInputControllers;
        public bool IsMovePressed { get; private set; }
        public float Movement { get; private set; }
        public float Rotation { get; private set; }
        
        public void Awake()
        {
            _movableInputControllers = new List<IMovableInputController>();

            var input = new KeyboardInputController();
            
            _movableInputControllers.Add(input);

            foreach (var controller in _movableInputControllers)
            {
                controller.OnMovePressed += MovePressed;
                controller.OnMove += UpdateDirection;
                controller.Init();
            }
        }

        public void Start()
        {
            foreach (var controller in _movableInputControllers)
            {
                controller?.Start();
            }
        }
        
        private void MovePressed(bool isMovePressed)
        {
            IsMovePressed = isMovePressed;
            OnMove?.Invoke(isMovePressed);
        }

        private void UpdateDirection(float movement, float rotation)
        {
            Movement = movement;
            Rotation = rotation;
        }

        public void Update()
        {
            foreach (var controller in _movableInputControllers)
            {
                controller?.Update();
            }
        }

        public void OnDestroy()
        {
            foreach (var controller in _movableInputControllers)
            {
                controller.OnMovePressed -= MovePressed;
                controller.OnMove -= UpdateDirection;
                controller.Disable();
            }
        }
    }
}