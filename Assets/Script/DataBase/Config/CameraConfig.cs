using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EHack2024.DataSystem.Configs{
    [CreateAssetMenu(fileName ="Camera Config")]
    public class CameraConfig : ScriptableObject
    {
        [field : SerializeField, Range(0,1)] public float cameraDelta {get; private set;} = 0.3f;
    }
}
