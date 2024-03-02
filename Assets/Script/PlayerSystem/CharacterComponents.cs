using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EHack2024.CharacterSystem{
    public class CharacterComponents : MonoBehaviour
    {
        [field:SerializeField] public CharacterController characterController { get; private set;}
        [field:SerializeField] public Transform FollowTargetTransform { get; private set;}
        [SerializeField] private Transform HandPosition;
        [SerializeField] private Transform BackPosition;
        [SerializeField] private Transform Gun;
        [SerializeField] public Transform GunPoint;
        public void ChangeGunStatus(bool onChangeGun)
        {
            Gun.transform.SetParent(onChangeGun?HandPosition : BackPosition);
            Gun.transform.localPosition = Vector3.zero;
            Gun.transform.localRotation = Quaternion.identity;
        }
    }
}
