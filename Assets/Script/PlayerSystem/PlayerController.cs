using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.CharacterSystem;
using EHack2024.DataSystem.Configs;
using EHack2024.EntitySystem;
using EHack2024.InputSystem;
using EHack2024.Pool;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : IEntity, IDisposable
{
    // Start is called before the first frame update
    private CharacterStateMachine characterStateMachine;
    private InputHandler inputHandler;
    private CharacterComponents characterComponents;
    private PlayerHealth playerHealth;
    public PlayerController(CharacterComponents characterComponents, InputHandler inputHandler, PlayerConfig playerConfig, Meteroid projectile,
     PoolFabric poolFabric, PlayerHealth playerHealth)
    {
        this.inputHandler = inputHandler;
        characterStateMachine = new CharacterStateMachine(characterComponents, inputHandler, playerConfig, projectile, poolFabric);
        this.characterComponents = characterComponents;
        inputHandler.walkOrRun += OnWalkOrRun;
        inputHandler.shoot += ChangeToShootState;
        this.playerHealth = playerHealth;
        characterComponents.GotHit+= GotHit;

    }

    private void GotHit()
    {
        playerHealth.RemoveHealth(1);
    }

    private void ChangeToShootState()
    {
        characterStateMachine.ChangeState(characterStateMachine.CharacterShootState);
        characterStateMachine.CanChangeState = false;
    }

    private void OnWalkOrRun(bool obj)
    {    
        characterStateMachine.ChangeState(!obj? characterStateMachine.CharacterIdleState : characterStateMachine.CharacterRunState);
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
