using System.Collections;
using System.Collections.Generic;
using EHack2024.DataSystem.Configs;
using EHack2024.EntitySystem;
using EHack2024.Pool;
using UnityEngine;

namespace EHack2024.MeteriodSystem{
    public class MeteriodController : IEntity
    {
        private OrbsConfig orbsConfig;
        private float time = .3f;
        private float tempTime = 0;
        private Transform player;
        private const float height = 100;
        private IPool<Meteroid> pool;
        public MeteriodController(OrbsConfig orbsConfig, Meteroid meteroid, Transform player, PoolFabric poolFabric)
        {
            this.orbsConfig = orbsConfig;
            this.player = player;
            pool = poolFabric.CreatePool(meteroid);
        }

        public void UpdateEntity()
        {
            tempTime +=Time.deltaTime;
            if(tempTime > time){
                tempTime = 0;
                Vector3 position;
                if(Random.Range(0,1f)< .5f)
                    position = new Vector3(Random.Range(-orbsConfig.RangeX, orbsConfig.RangeX), height ,Random.Range(-orbsConfig.RangeY, orbsConfig.RangeY));
                else
                    position = new Vector3( player.position.x, height, player.position.z);
                var meteroid = pool.Request();
                meteroid.transform.position = position;
                meteroid.transform.rotation = Quaternion.identity;
                meteroid.pool = pool;
            }
        }
    }

}