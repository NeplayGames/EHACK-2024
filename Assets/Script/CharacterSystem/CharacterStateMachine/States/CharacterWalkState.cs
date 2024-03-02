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
    
        public CharacterWalkState(CharacterComponents characterComponents, InputHandler inputHandler) : base(characterComponents)
        {
            this.InputHandler = inputHandler;
        }

        public override void Enter()
        {
            // Quaternion localRot =CharacterComponents.FollowTargetTransform.localRotation; 
            // CharacterComponents.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            // CharacterComponents.FollowTargetTransform.localRotation =
            //  new Quaternion(localRot.x, 0 ,0, localRot.w);
            InputHandler.changeDirection += ChnageDirection;
        }

        private void ChnageDirection(float arg1, float arg2)
        {
            Debug.Log(arg2);
           CharacterComponents.characterController.Move(new Vector3(arg1, 0, arg2));
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
