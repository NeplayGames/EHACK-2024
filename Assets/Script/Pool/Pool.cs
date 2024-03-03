using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EHack2024.Pool
{
    public interface IPool<T>
    {      
        public T Request();
        public void Return(T member);      
        public void Clear();
    }

    public class Pool<T> : IPool<T>
    {
        private readonly Stack<T> _available = new();
        private readonly T _prefab;


        public Func<T, T> Create { get; set; }
        public Action<T> ReturnObject, RequestObject;

        public Pool(T prefab)
        {
            _prefab = prefab;
        }

        public T Request()
        {
            T member = _available.Count > 0 ? _available.Pop() : Create(_prefab);
            RequestObject(member);
            return member;
        }

        public void Return(T member)
        {
            _available.Push(member);
            ReturnObject(member);
        }

        public void Clear()
        {
            foreach (T availableObject in _available)
            {
                Component component = availableObject as Component;
                Object.Destroy(component.gameObject);
            }
            _available.Clear();
        }
    }
}