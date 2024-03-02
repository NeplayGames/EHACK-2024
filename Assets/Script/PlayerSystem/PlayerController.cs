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
    private CharacterController CharacterController;
    private CharacterStateMachine characterStateMachine;
    private InputHandler inputHandler;
    public PlayerController(CharacterController characterController, InputHandler inputHandler)
    {
        this.CharacterController = characterController;
        characterStateMachine = new CharacterStateMachine(characterController);
        this.inputHandler = inputHandler;
        inputHandler.changeDirection += OnChageDirection;
    }

    private void OnChageDirection(float arg1, float arg2)
    {
        CharacterController.Move(new Vector3(arg1, 0, arg2));
    }

    // Update is called once per frame

    public void UpdateEntity()
    {
        characterStateMachine?.Update();
    }

    public void Dispose()
    {
        inputHandler.changeDirection -= OnChageDirection;
    }
}
