using System.Collections;
using System.Collections.Generic;
using EHack2024.CharacterSystem.States;
using EHack2024.DataSystem.Configs;
using EHack2024.InputSystem;
using EHack2024.Pool;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem{
    public class CharacterStateMachine : StateMachine
    {
        public bool CanChangeState = true;
        public CharacterRunState CharacterRunState {get; private set;}
        public CharacterWalkState CharacterWalkState {get; private set;}
        public CharacterShootState CharacterShootState {get; private set;}
         public CharacterIdleState CharacterIdleState {get; private set;}
        public CharacterStateMachine(CharacterComponents characterComponents, InputHandler inputHandler, PlayerConfig playerConfig, PoolObject projectile, PoolFabric poolFabric)
        {
            CreateStates(characterComponents, inputHandler, playerConfig, projectile, poolFabric);
        }

        private void CreateStates(CharacterComponents characterComponent, InputHandler inputHandler, PlayerConfig playerConfig, PoolObject projectile, PoolFabric poolFabric){
            CharacterRunState = new CharacterRunState(characterComponent, inputHandler, playerConfig);
            CharacterShootState = new CharacterShootState(characterComponent, projectile, poolFabric, this);
            CharacterWalkState = new CharacterWalkState(characterComponent, inputHandler, playerConfig);
            CharacterIdleState = new CharacterIdleState(characterComponent);
        }
        public override void ChangeState(IState newState)
        {
            if(CanChangeState)
                base.ChangeState(newState);
        }
    }
}
