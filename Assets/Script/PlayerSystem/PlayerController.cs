using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.CharacterSystem;
using EHack2024.EntitySystem;
using EHack2024.InputSystem;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : IEntity, IDisposable
{
    // Start is called before the first frame update
    private CharacterStateMachine characterStateMachine;
    private InputHandler inputHandler;
    public PlayerController(CharacterComponents characterComponents, InputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
        characterStateMachine = new CharacterStateMachine(characterComponents, inputHandler);
        inputHandler.walkOrRun += OnWalkOrRun;
    }

    private void OnWalkOrRun(bool obj)
    {
        characterStateMachine.ChangeState(characterStateMachine.CharacterWalkState);
    }

    

    // Update is called once per frame

    public void UpdateEntity()
    {
        characterStateMachine?.Update();
    }

    public void Dispose()
    {
        inputHandler.walkOrRun -= OnWalkOrRun;
    }
}
