using UnityEngine;
using UnityEngine.Serialization;

namespace EHack2024.Pool
{
   
    public class PoolFabric 
    {

        public IPool<T> CreatePool<T>(T item) where T : Component
        {
            Pool<T> pool = new(item);
          
            T PoolCreate(T view) => GameObject.Instantiate(item);

            pool.Create = PoolCreate;


            void PoolReturnObject(T view)
            {
                view.gameObject.SetActive(false);            
            }

            pool.ReturnObject = PoolReturnObject;

            void PoolRequestObject(T view)
            {
                view.gameObject.SetActive(true);        
            }

            pool.RequestObject = PoolRequestObject;

            return pool;
        }

    }
}