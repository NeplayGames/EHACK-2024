using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EHack2024.StateMachineSystem{
    public interface  IState
    {
        public void Enter();
        public void Update();
        public void Exit();
    }
}
