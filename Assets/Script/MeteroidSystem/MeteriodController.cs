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
        private float time = .1f;
        private float tempTime = 0;
        private float meteroidTime = 1f;
        private float meteroidtempTime = 0;
        private Transform player;
        private const float height = 50;
        private IPool<PoolObject> pool;
        public MeteriodController(OrbsConfig orbsConfig, PoolObject meteroid, Transform player, PoolFabric poolFabric)
        {
            this.orbsConfig = orbsConfig;
            this.player = player;
            pool = poolFabric.CreatePool(meteroid);
        }

        public void UpdateEntity()
        {
            tempTime +=Time.deltaTime;
            meteroidtempTime +=Time.deltaTime;
                Vector3 position;
            if(meteroidtempTime > meteroidTime)
            {
                meteroidtempTime = 0;
                position = new Vector3(player.position.x, height/3, player.position.z);
                InstantiateMeteroid(position);
            }
            if (tempTime > time){
                tempTime = 0;
                position = new Vector3(Random.Range(-orbsConfig.RangeX, orbsConfig.RangeX), height ,Random.Range(-orbsConfig.RangeY, orbsConfig.RangeY));
                 InstantiateMeteroid(position);
            }
        }

        private void InstantiateMeteroid(Vector3 position)
        {
            var meteroid = pool.Request();
            meteroid.transform.position = position;
            meteroid.transform.rotation = Quaternion.identity;
            meteroid.pool = pool;
        }
    }

}
