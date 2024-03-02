using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.InputSystem;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public class CharacterWalkState : CharacterBaseState
    {
        private InputHandler InputHandler;
       public CharacterWalkState(CharacterController characterController, InputHandler inputHandler) : base(characterController)
        {
            InputHandler = inputHandler;
        }

        public override void Enter()
        {
            InputHandler.changeDirection += ChnageDirection;
        }

        private void ChnageDirection(float arg1, float arg2)
        {
            characterController.Move(new Vector3(arg1, 0, arg2));
        }

        public override void Exit()
        {
             InputHandler.changeDirection -= ChnageDirection;
        }

        public override void Update()
        {
        }
    }
}
