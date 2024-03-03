using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteroid : PoolObject
{
    [SerializeField] public Rigidbody rigidbodys;

    protected override void OnEnable()
    {
        if(rigidbodys!=null)
         rigidbodys.isKinematic = false;
        base.OnEnable();
    }

    protected override void Deactive()
    {
          if(rigidbodys!=null)
        rigidbodys.isKinematic = true;
        base.Deactive();
    }
}
