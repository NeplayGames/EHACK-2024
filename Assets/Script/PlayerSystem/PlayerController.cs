using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.CharacterSystem;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    // Start is called before the first frame update

    private CharacterStateMachine characterStateMachine;
    void Start()
    {
        Intialize();
    }

    private void Intialize()
    {
        characterStateMachine = new CharacterStateMachine(characterController);
    }

    // Update is called once per frame
    void Update()
    {
        characterStateMachine?.Update();
    }

    void OnValidate(){
        Assert.IsNotNull(characterController, $"{nameof(characterController)} cannot be null in {name}");
    }
}
