using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.EntitySystem;
using UnityEngine;

namespace EHack2024.InputSystem{
    public class InputHandler : IEntity
    {
        public event Action<float, float> changeDirection;
        public event Action changePickStatus;
        public event Action<Vector2> mousePosition;
        public event Action shoot; 
    
        private void HandlePickUpAction()
        {
             if(Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.P)){
                changePickStatus?.Invoke();
            }
        }

        private void HandleShootAction()
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
                shoot?.Invoke();
            }
        }

        private void HandleMouseMovement()
        {
            if(Input.GetMouseButton(0)){
                mousePosition?.Invoke(Input.mousePosition);
            }
        }

        private void HandlingMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (horizontal != 0 || vertical != 0)
            {
                changeDirection?.Invoke(horizontal, vertical);
            }
        }

        public void UpdateEntity()
        {
             HandlingMovement();
            HandleMouseMovement();
            HandleShootAction();
            HandlePickUpAction();
        }
    }
}
