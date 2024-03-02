using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EHack2024.DataSystem{
    
    [CreateAssetMenu(fileName = "DataBase")]
    public class DataBase : ScriptableObject
    {
        [field:SerializeField] public GameObject Player { get; private set;}
    }
}
