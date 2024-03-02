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
        public CharacterStateMachine(CharacterComponents characterComponents, InputHandler inputHandler)
        {
            CreateStates(characterComponents, inputHandler);
        }

        private void CreateStates(CharacterComponents characterComponent, InputHandler inputHandler){
            CharacterRunState = new CharacterRunState(characterComponent);
            CharacterShootState = new CharacterShootState(characterComponent);
            CharacterWalkState = new CharacterWalkState(characterComponent, inputHandler);
            CharacterIdleState = new CharacterIdleState(characterComponent);
            ChangeState(CharacterIdleState);
        }
    }
}
