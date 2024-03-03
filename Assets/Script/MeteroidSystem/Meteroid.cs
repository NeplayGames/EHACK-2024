using System.Collections;
using System.Collections.Generic;
using EHack2024.Pool;
using UnityEngine;

public class Meteroid : MonoBehaviour
{
   public IPool<Meteroid> pool;
    [SerializeField, Range(5,100)] private float deactiveTime = 5;
    void OnEnable(){
        Invoke(nameof(Deactive), deactiveTime);
    }

    private void Deactive(){
        pool.Return(this);
    }
}
