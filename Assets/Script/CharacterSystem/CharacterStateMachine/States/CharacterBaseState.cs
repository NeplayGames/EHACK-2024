using System.Collections;
using System.Collections.Generic;
using EHack2024.AnimationSystem;
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

        protected void PlayAnimation(int hash){
            ResetAllTriggers(this.CharacterComponents.animator);
            this.CharacterComponents.animator.SetTrigger(hash);
        }
        private void ResetAllTriggers(Animator animator)
        {
            foreach (var param in animator.parameters)
            {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                animator.ResetTrigger(param.name);
            }
        }
}
        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }

}
