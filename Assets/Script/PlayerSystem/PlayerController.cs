using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.CharacterSystem;
using EHack2024.DataSystem.Configs;
using EHack2024.EntitySystem;
using EHack2024.InputSystem;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : IEntity, IDisposable
{
    // Start is called before the first frame update
    private CharacterStateMachine characterStateMachine;
    private InputHandler inputHandler;
    private CharacterComponents characterComponents;
    private GameObject projectile;
    private bool OnChangeGun = false;
    public PlayerController(CharacterComponents characterComponents, InputHandler inputHandler, PlayerConfig playerConfig, GameObject projectile)
    {
        this.inputHandler = inputHandler;
        characterStateMachine = new CharacterStateMachine(characterComponents, inputHandler, playerConfig);
        this.characterComponents = characterComponents;
        this.projectile = projectile;
        inputHandler.walkOrRun += OnWalkOrRun;
        inputHandler.changePickStatus += ChangeGun;
        inputHandler.shoot += ShootGun;
    }


    private void ChangeGun()
    {
        OnChangeGun = !OnChangeGun;
        characterComponents.ChangeGunStatus(OnChangeGun);
        characterStateMachine.ChangeState(OnChangeGun 
        ? characterStateMachine.CharacterWalkState : characterStateMachine.CharacterRunState);
    }

    private void OnWalkOrRun(bool obj)
    {    
        characterStateMachine.ChangeState(!obj? characterStateMachine.CharacterIdleState :OnChangeGun 
        ? characterStateMachine.CharacterWalkState : characterStateMachine.CharacterRunState);
    }

    private void ShootGun(){  
        Rigidbody rigidbody = GameObject.Instantiate(projectile, characterComponents.GunPoint.position, 
        Quaternion.identity).GetComponent<Rigidbody>();    
        rigidbody.isKinematic = false;
        Vector3 direction =  characterComponents.GunPoint.up; 
        rigidbody.AddForce (direction * 3000); 
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
