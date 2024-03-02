using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EHack2024.DataSystem.Configs{
    [CreateAssetMenu(fileName ="Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        [field : SerializeField, Range(0,100)] public float playerWalkSpeed {get; private set;} = 0.3f;
        [field : SerializeField, Range(0,100)] public float playerRunSpeed {get; private set;} = 0.3f;
    }
}
