using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public class CharacterShootState : CharacterBaseState
    {
        private GameObject projectile;
        public CharacterShootState(CharacterComponents characterComponents, GameObject projectile) : base(characterComponents)
        {
            this.projectile = projectile;
        }

        public override void Enter()
        {
             PlayAnimation(CharacterComponents.CharacterAnimationConfig.ShootHash);
        }

        private void AnimationAction()
        {
            ShootGun();
        }
        private void ShootGun(){  
            Rigidbody rigidbody = GameObject.Instantiate(projectile, CharacterComponents.GunPoint.position, 
            Quaternion.identity).GetComponent<Rigidbody>();    
            rigidbody.isKinematic = false;
            Vector3 direction =  CharacterComponents.GunPoint.up; 
            rigidbody.AddForce (direction * 3000); 
    }
        public override void Exit()
        {

        }

        public override void Update()
        {
        }
    }
}
