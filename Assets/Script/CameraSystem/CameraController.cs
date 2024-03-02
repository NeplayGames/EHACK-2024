using EHack2024.DataSystem.Configs;
using EHack2024.InputSystem;
using UnityEngine;
namespace EHack2024.CameraSystem{
    public class CameraController 
    {
        private const float Threshold = 0.01f;
        private float targetYaw;
        private float targetPitch;
        private InputHandler inputHandler;
        private Transform CameraPosition; 
        private CameraConfig cameraConfig {get;}
        public CameraController(InputHandler inputHandler,Transform cameraPostion, CameraConfig cameraConfig){
            this.inputHandler = inputHandler;
            CameraPosition = cameraPostion;
            this.cameraConfig = cameraConfig;
            this.inputHandler.mousePosition += CameraFreeRotation;
        }

        public void CameraFreeRotation(Vector2 mousePosition)
        {
            // if there is an input and camera position is not fixed
            if (mousePosition.sqrMagnitude >= Threshold)
            {
                
                var look = mousePosition;
                if (mousePosition.x < cameraConfig.cameraDelta && mousePosition.x > - cameraConfig.cameraDelta)
                    look = new Vector2(0, mousePosition.y);

                if (mousePosition.y < cameraConfig.cameraDelta && mousePosition.y > - cameraConfig.cameraDelta)
                    look = new Vector2(mousePosition.x, 0);

                var eulerAngles = CameraPosition.eulerAngles;
                targetYaw = eulerAngles.y;
                targetPitch = AdjustPitchToCurrentView();

                targetYaw += look.x ;
                targetPitch -= look.y;

                // clamp our rotations so our values are limited 360 degrees
                targetYaw = ClampAngle(targetYaw, -360, 360);
                targetPitch = ClampAngle(targetPitch, -10, 25);

                // Cinemachine will follow this target
                CameraPosition.rotation = RotateCameraTarget(targetPitch, targetYaw);

                float AdjustPitchToCurrentView()
                {
                    if (eulerAngles.x > 90)
                        return eulerAngles.x - 360;
                    return eulerAngles.x;
                }
            }

        }
        private Quaternion RotateCameraTarget(float pitch, float yaw)
        {
            return Quaternion.Euler(pitch , yaw , 0.0f);
        }

         private float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f)
                lfAngle += 360f;
            if (lfAngle > 360f)
                lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}
