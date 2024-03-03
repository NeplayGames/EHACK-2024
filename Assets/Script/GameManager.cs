using System;
using System.Collections;
using System.Collections.Generic;
using EHack2024.CameraSystem;
using EHack2024.CharacterSystem;
using EHack2024.DataSystem;
using EHack2024.EntitySystem;
using EHack2024.InputSystem;
using EHack2024.MeteriodSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace EHack2024.GameManger{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private DataBase dataBase;
        private List<IEntity> entities = new List<IEntity>();
        private InputHandler inputHandler;
        void Start(){
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            Initialize();
        }

        private void Initialize()
        {
            var characterController = Instantiate(dataBase.Player).GetComponent<CharacterComponents>();
            inputHandler = new InputHandler();
            PlayerController playerController = new PlayerController(characterController ,inputHandler, dataBase.playerConfig, dataBase.projectile);
            CameraController cameraController = new CameraController(inputHandler,characterController.FollowTargetTransform, dataBase.cameraConfig);
            MeteriodController meteriodController = new MeteriodController(dataBase.orbsConfig, dataBase.meteroid, characterController.transform );
            entities.Add(playerController);
            entities.Add(inputHandler);
            entities.Add(meteriodController);
        }

        void Update(){
            foreach(var entity in entities){
                entity?.UpdateEntity();
            }
        }
    }
}
