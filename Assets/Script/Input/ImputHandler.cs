using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EHack2024.InputSystem{
    public class ImputHandler 
    {
        public event Action<float, float> changeDirection;
        public event Action changePickStatus;
        public event Action<Vector2> mousePosition;
        public event Action shoot; 
        public void Update()
        {
            HandlingMovement();
            HandleMouseMovement();
            HandleShootAction();
            HandlePickUpAction();
        }

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
    }
}
