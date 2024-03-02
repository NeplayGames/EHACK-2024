using System.Collections;
using System.Collections.Generic;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public abstract class CharacterBaseState : IState
    {
        protected CharacterComponents CharacterComponents {get;}
        public CharacterBaseState(CharacterComponents characterComponents)
        {
            this.CharacterComponents = characterComponents;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }

}
