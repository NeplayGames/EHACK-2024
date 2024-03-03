using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.Pool;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public class CharacterShootState : CharacterBaseState
    {
        private IPool<Meteroid> pool;
        private float time = .7f;
        private float tempTime = 0;
        private CharacterStateMachine characterStateMachine;
        public CharacterShootState(CharacterComponents characterComponents, Meteroid projectile, PoolFabric poolFabric, CharacterStateMachine characterStateMachine) : base(characterComponents)
        {
            this.pool = poolFabric.CreatePool(projectile);
            this.characterStateMachine = characterStateMachine;
        }

        public override void Enter()
        {
            tempTime = 0;
             PlayAnimation(CharacterComponents.CharacterAnimationConfig.ShootHash);
        }

        private void AnimationAction()
        {
            ShootGun();
        }
        private void ShootGun(){  
            Meteroid meteroid = pool.Request();
            meteroid.transform.position =  CharacterComponents.GunPoint.position;
            meteroid.transform.rotation = Quaternion.identity;
             meteroid.pool = pool;
            Rigidbody rigidbody = meteroid.GetComponent<Rigidbody>();    
            rigidbody.isKinematic = false;
            Vector3 direction =  CharacterComponents.GunPoint.forward; 
            rigidbody.AddForce (direction * 9000); 
    }
        public override void Exit()
        {

        }

        public override void Update()
        {
            tempTime += UnityEngine.Time.deltaTime;
            if(tempTime > time){
                tempTime = 0;       
            ShootGun();
            characterStateMachine.CanChangeState = true;
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical")!=0)
            characterStateMachine.ChangeState(characterStateMachine.CharacterRunState);      
            else
             characterStateMachine.ChangeState(characterStateMachine.CharacterIdleState);      
           
            }
               
        }
    }
}
