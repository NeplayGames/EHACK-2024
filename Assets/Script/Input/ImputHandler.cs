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
        private bool isMoving = false;
        private bool IsMoving {
            set{
                if(value != isMoving){
                    isMoving = value;
                    walkOrRun?.Invoke(isMoving);
                }
            }
            get{
               return isMoving;
            }
        }
        public event Action<bool> walkOrRun;

        public InputHandler()
        {
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
            Vector2 currentPos = new Vector2(Input.GetAxis("Mouse X") ,Input.GetAxis("Mouse Y"));
           // if(currentPos != mousePo){
                mousePosition?.Invoke(currentPos);
            //}
        }

        private void HandlingMovement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            IsMoving = horizontal != 0 || vertical != 0;
            if (IsMoving)
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
