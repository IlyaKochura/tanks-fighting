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

        public event Action FireEvent;
        public event Action LeftWeaponSelect;
        public event Action RightWeaponSelect;

        // public bool Fire { get; private set; }
        // public bool LeftWeaponSelect { get; private set; }
        // public bool RightWeaponSelect { get; private set; }
        
        public void Awake()
        {
            _movableInputControllers = new List<IMovableInputController>();

            var input = new KeyboardInputController();
            
            _movableInputControllers.Add(input);

            foreach (var controller in _movableInputControllers)
            {
                controller.OnMovePressed += MovePressed;
                controller.OnMove += UpdateDirection;
                controller.OnFirePressed += UpdateFire;
                controller.OnLeftWeaponSelected += UpdateLeftWeaponSelected;
                controller.OnRightWeaponSelected += UpdateRightWeaponSelected;
                controller.Init();
            }
        }

        private void UpdateRightWeaponSelected(bool obj)
        {
            RightWeaponSelect?.Invoke();
        }

        private void UpdateLeftWeaponSelected(bool obj)
        {
            LeftWeaponSelect?.Invoke();
        }

        private void UpdateFire(bool fire)
        {
            FireEvent?.Invoke();
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
                controller.OnFirePressed -= UpdateFire;
                controller.OnLeftWeaponSelected -= UpdateLeftWeaponSelected;
                controller.OnRightWeaponSelected -= UpdateRightWeaponSelected;
                controller.Disable();
            }
        }
    }
}