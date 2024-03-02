using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EHack2024.StateMachine{
    public abstract class StateMachine 
    {
        public IState CurrentState { get; set; }

        public virtual void ChangeState(IState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void Update() => CurrentState?.Update();
    }
}
