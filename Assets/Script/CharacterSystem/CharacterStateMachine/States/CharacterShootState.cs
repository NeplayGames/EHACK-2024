using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.Pool;
using EHack2024.StateMachineSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem.States{
    public class CharacterShootState : CharacterBaseState
    {
        private IPool<PoolObject> pool;
        private float time = .7f;
        private float tempTime = 0;
        private CharacterStateMachine characterStateMachine;
        public CharacterShootState(CharacterComponents characterComponents, PoolObject projectile, PoolFabric poolFabric, CharacterStateMachine characterStateMachine) : base(characterComponents)
        {
            this.pool = poolFabric.CreatePool(projectile);
            this.characterStateMachine = characterStateMachine;
        }

        public override void Enter()
        {
            tempTime = 0;
             var localRot = CharacterComponents.FollowTargetTransform.eulerAngles; 
            CharacterComponents.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            CharacterComponents.FollowTargetTransform.localEulerAngles =
            new Vector3(localRot.x, 0 ,0);
             PlayAnimation(CharacterComponents.CharacterAnimationConfig.ShootHash);
        }

        private void ShootGun(){  
            Bullet meteroid = (Bullet)pool.Request();
            meteroid.transform.position =  CharacterComponents.GunPoint.position;
            meteroid.transform.rotation = Quaternion.identity;
            Vector3 direction =  Camera.main.transform.forward.normalized; 
            meteroid.Direction = new Vector3(direction.x, 0, direction.z);
             meteroid.pool = pool;       
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
