using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EHack2024.CharacterSystem{
    public class CharacterComponents : MonoBehaviour
    {
        [field:SerializeField] public CharacterController characterController { get; private set;}
        [field:SerializeField] public Transform FollowTargetTransform { get; private set;}
    }
}
