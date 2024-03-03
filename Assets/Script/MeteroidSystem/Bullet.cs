using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObject
{
    public Vector3 Direction {set; private get;}

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * 100 * Time.deltaTime;
    }
}
