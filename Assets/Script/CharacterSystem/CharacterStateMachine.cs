using System.Collections;
using System.Collections.Generic;
using EHack2024.CharacterSystem.States;
using EHack2024.InputSystem;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem{
    public class CharacterStateMachine : StateMachine
    {
        public CharacterRunState CharacterRunState {get; private set;}
        public CharacterWalkState CharacterWalkState {get; private set;}
        public CharacterShootState CharacterShootState {get; private set;}
         public CharacterIdleState CharacterIdleState {get; private set;}
        public CharacterStateMachine(CharacterController characterController, InputHandler inputHandler)
        {
            CreateStates(characterController, inputHandler);
        }

        private void CreateStates(CharacterController characterController, InputHandler inputHandler){
            CharacterRunState = new CharacterRunState(characterController);
            CharacterShootState = new CharacterShootState(characterController);
            CharacterWalkState = new CharacterWalkState(characterController, inputHandler);
            CharacterIdleState = new CharacterIdleState(characterController);
            ChangeState(CharacterIdleState);
        }
    }
}
