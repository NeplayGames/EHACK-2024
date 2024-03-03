using System.Collections;
using System.Collections.Generic;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public class CharacterIdleState: CharacterBaseState
    {
       
        public CharacterIdleState(CharacterComponents characterComponents) : base(characterComponents)
        {
        }

        public override void Enter()
        {
            PlayAnimation(CharacterComponents.CharacterAnimationConfig.IdleHash);
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
        }
    }

}
