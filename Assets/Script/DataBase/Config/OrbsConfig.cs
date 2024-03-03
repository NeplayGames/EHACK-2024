using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EHack2024.DataSystem.Configs{
    [CreateAssetMenu(fileName ="Orbs Config")]
    public class OrbsConfig : ScriptableObject
    {
        [field : SerializeField, Range(0,1)] public float RangeX {get; private set;} = 11;
        [field : SerializeField, Range(0,1)] public float RangeY {get; private set;} = 7;
    }
}
