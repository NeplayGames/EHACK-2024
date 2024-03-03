using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.AnimationSystem;
using UnityEngine;

namespace EHack2024.CharacterSystem{
    public class CharacterComponents : MonoBehaviour
    {
        [field:SerializeField] public CharacterController characterController { get; private set;}
        [field:SerializeField] public Transform FollowTargetTransform { get; private set;}
        [SerializeField] private Transform HandPosition;
        [SerializeField] private Transform BackPosition;
        [SerializeField] public Transform GunPoint;
        [SerializeField] public Animator animator;
        public event Action GotHit;
        private CharacterAnimationConfig characterAnimationConfig;
        public CharacterAnimationConfig CharacterAnimationConfig{
            get{
                if(characterAnimationConfig == null){
                    characterAnimationConfig = new CharacterAnimationConfig();
                }
                return characterAnimationConfig;
            }
        }

        public void OnCollisionEnter(Collision collision){
            if(collision.transform.CompareTag("Meteroid")){
               // animator.SetTrigger("Hit");
                GotHit?.Invoke();
            }
        }


    }
}
