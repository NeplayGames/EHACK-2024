using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.CharacterSystem;
using EHack2024.EntitySystem;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : IEntity
{
    // Start is called before the first frame update

    private CharacterStateMachine characterStateMachine;
    public void Intialize(CharacterController characterController)
    {
        characterStateMachine = new CharacterStateMachine(characterController);
    }

    // Update is called once per frame

    public void UpdateEntity()
    {
        characterStateMachine?.Update();
    }
}
