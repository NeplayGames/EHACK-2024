using System.Collections;
using System.Collections.Generic;
using EHack2024.Pool;
using Unity.VisualScripting;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
   public IPool<PoolObject> pool;
    [SerializeField, Range(5,100)] private float deactiveTime = 5;
    protected virtual void OnEnable(){
        
        Invoke(nameof(Deactive), deactiveTime);
    }

    void OnCollisionEnter(Collision collision){
        //if(collision.transform.CompareTag(tagName))
            Deactive();
    }
    protected virtual void Deactive(){
      
        pool.Return(this);
        
    }
}
