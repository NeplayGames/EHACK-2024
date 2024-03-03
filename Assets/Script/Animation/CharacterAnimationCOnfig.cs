using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EHack2024.AnimationSystem{
    public class CharacterAnimationConfig 
    {
        private string Run = "Run";
        private string Walk = "Hit";
        private string Idle = "Idle";
        private string Shoot = "Shoot";

        public CharacterAnimationConfig(){
            RunHash = Animator.StringToHash(Run);
            IdleHash = Animator.StringToHash(Idle);
            HitHash = Animator.StringToHash(Walk);
            ShootHash = Animator.StringToHash(Shoot);
        }

        public int RunHash {get;}
        public int IdleHash {get;}
        public int HitHash {get;}
        public int ShootHash {get;}
    }
}
