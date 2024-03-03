using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.CameraSystem;
using EHack2024.CharacterSystem;
using EHack2024.DataSystem;
using EHack2024.EntitySystem;
using EHack2024.InputSystem;
using EHack2024.MeteriodSystem;
using EHack2024.Pool;
using UnityEngine;
using UnityEngine.UIElements;

namespace EHack2024.GameManger{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private DataBase dataBase;
        [SerializeField] private UIView uIView;
        private List<IEntity> entities = new List<IEntity>();
        private InputHandler inputHandler;
        private PoolFabric poolFabric;
        private CharacterComponents characterComponents;
        private PlayerHealth playerHealth;
        private bool gameOver = false;
        void Start(){
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            Initialize();
        }

        private void Initialize()
        {
            playerHealth = new();
            uIView.Initial(playerHealth);
            poolFabric = new PoolFabric();
            characterComponents = Instantiate(dataBase.Player).GetComponent<CharacterComponents>();
            inputHandler = new InputHandler();
            PlayerController playerController = new PlayerController(characterComponents ,inputHandler, dataBase.playerConfig, dataBase.projectile, poolFabric, playerHealth);
            CameraController cameraController = new CameraController(inputHandler,characterComponents.FollowTargetTransform, dataBase.cameraConfig);
            MeteriodController meteriodController = new MeteriodController(dataBase.orbsConfig, dataBase.meteroid, characterComponents.transform, poolFabric);
            entities.Add(playerController);
            entities.Add(inputHandler);
            entities.Add(meteriodController);
            playerHealth.Died += GameOver;
        }

        private void GameOver()
        {
            gameOver =true;
            Destroy(characterComponents.gameObject);
        }

        void Update(){
            if(gameOver) return;
            foreach(var entity in entities){
                entity?.UpdateEntity();
            }
        }
    }
}
