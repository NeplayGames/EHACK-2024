using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.DataSystem.Configs;
using EHack2024.InputSystem;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public abstract class CharacterMoveState : CharacterBaseState
    {
        private InputHandler InputHandler;
        protected float speed {private get ; set;}
        public CharacterMoveState(CharacterComponents characterComponents, InputHandler inputHandler) : base(characterComponents)
        {
            this.InputHandler = inputHandler;
        }

        public override void Enter()
        {
           
            InputHandler.changeDirection += ChnageDirection;
        }

        private void ChnageDirection(float arg1, float arg2)
        {
            Vector3 movementDirection = (CharacterComponents.transform.forward * arg2) +
            (CharacterComponents.transform.right * arg1);
           CharacterComponents.characterController.SimpleMove(movementDirection * Time.deltaTime * speed);
        }

        public override void Exit()
        {
             InputHandler.changeDirection -= ChnageDirection;
        }

        public override void Update()
        {
             var localRot = CharacterComponents.FollowTargetTransform.eulerAngles; 
             CharacterComponents.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
             CharacterComponents.FollowTargetTransform.localEulerAngles =
              new Vector3(localRot.x, 0 ,0);
        }
    }
}
