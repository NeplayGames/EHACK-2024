using System.Collections;
using System.Collections.Generic;
using EHack2024.Pool;
using Unity.VisualScripting;
using UnityEngine;

public class Meteroid : MonoBehaviour
{
   public IPool<Meteroid> pool;
    [SerializeField, Range(5,100)] private float deactiveTime = 5;
    [SerializeField] private string tagName;
    [SerializeField] public Rigidbody rigidbodys;
    void OnEnable(){
         rigidbodys.isKinematic = false;
        Invoke(nameof(Deactive), deactiveTime);
    }

    void OnCollisionEnter(Collision collision){
        //if(collision.transform.CompareTag(tagName))
            Deactive();
    }
    private void Deactive(){
        rigidbodys.isKinematic = true;
        pool.Return(this);
        
    }
}
