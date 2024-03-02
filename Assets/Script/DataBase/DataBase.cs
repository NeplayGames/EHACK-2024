using System.Collections;
using System.Collections.Generic;
using EHack2024.DataSystem.Configs;
using UnityEngine;

namespace EHack2024.DataSystem{
    
    [CreateAssetMenu(fileName = "DataBase")]
    public class DataBase : ScriptableObject
    {
        [field:SerializeField] public GameObject Player { get; private set;}
        [field:SerializeField] public PlayerConfig playerConfig { get; private set;}
        [field:SerializeField] public CameraConfig cameraConfig{ get; private set;}
    }
}
