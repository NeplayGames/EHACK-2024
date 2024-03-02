using System.Collections;
using System.Collections.Generic;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public abstract class CharacterBaseState : IState
    {
        protected CharacterController characterController {get;}
        public CharacterBaseState(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }

}
