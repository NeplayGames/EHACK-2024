using System.Collections;
using System.Collections.Generic;
using EHack2024.DataSystem.Configs;
using EHack2024.EntitySystem;
using UnityEngine;

namespace EHack2024.MeteriodSystem{
    public class MeteriodController : IEntity
    {
        private OrbsConfig orbsConfig;
        private float time = .3f;
        private float tempTime = 0;
        private GameObject meteroid;
        private Transform player;
        private const float height = 100;
        public MeteriodController(OrbsConfig orbsConfig, GameObject meteroid, Transform player)
        {
            this.orbsConfig = orbsConfig;
            this.meteroid = meteroid;
            this.player = player;
        }

        public void UpdateEntity()
        {
            tempTime +=Time.deltaTime;
            if(tempTime > time){
                tempTime = 0;
                Vector3 position;
                if(Random.Range(0,1f)< 5f)
                    position = new Vector3(Random.Range(-orbsConfig.RangeX, orbsConfig.RangeX), height ,Random.Range(-orbsConfig.RangeY, orbsConfig.RangeY));
                else
                    position = new Vector3( player.position.x, height, player.position.z);
                GameObject.Instantiate(meteroid,position, Quaternion.identity);
            }
        }
    }

}
