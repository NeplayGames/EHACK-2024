using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.Pool;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public class CharacterShootState : CharacterBaseState
    {
        private IPool<Meteroid> projectile;
        public CharacterShootState(CharacterComponents characterComponents, Meteroid projectile, PoolFabric poolFabric) : base(characterComponents)
        {
            this.projectile = poolFabric.CreatePool(projectile);
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
            Meteroid meteroid = projectile.Request();
            meteroid.transform.position =  CharacterComponents.GunPoint.position;
            meteroid.transform.rotation = Quaternion.identity;
            Rigidbody rigidbody = meteroid.GetComponent<Rigidbody>();    
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
