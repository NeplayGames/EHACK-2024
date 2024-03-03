using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.DataSystem.Configs;
using EHack2024.InputSystem;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public class CharacterWalkState : CharacterMoveState
    {
    
        public CharacterWalkState(CharacterComponents characterComponents, InputHandler inputHandler, PlayerConfig playerConfig) : base(characterComponents, inputHandler)
        {
            speed = playerConfig.playerWalkSpeed;
        }

        public override void Enter()
        {
            PlayAnimation(CharacterComponents.CharacterAnimationConfig.HitHash);
            base.Enter();
        }

    }
}
