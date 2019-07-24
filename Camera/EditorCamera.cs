using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class EditorCamera : ICamera
    {
        private Vector3 defaultCamTarget = Vector3.Zero;
        private Vector3 defaultCamPosition = new Vector3(0, 0f, 5f);
        private float defaultFOV = 45f;
        private float defaultNearPlaneDistance = 1f;
        private float defaultFarPlaneDistance = 9999f;

        private CameraState cameraState;

        public EditorCamera(GraphicsDevice graphicsDevice)
        {
            cameraState = new CameraState(
                target: defaultCamTarget,
                position: defaultCamPosition,
                fieldOfView: MathHelper.ToRadians(defaultFOV),
                aspectRatio: graphicsDevice.DisplayMode.AspectRatio,
                nearPlaneDistance: defaultNearPlaneDistance,
                farPlaneDistance: defaultFarPlaneDistance
            );
        }

        public CameraState GetCameraState()
        {
            return cameraState;
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            var rotationScale = 5f;
            if (keyboardState.IsKeyDown(Keys.A))
            {
                cameraState.Position = Vector3.Add(cameraState.Position, new Vector3(-1f, 0f, 0f));
                cameraState.Target = Vector3.Add(cameraState.Target, new Vector3(-1f, 0f, 0f));
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                cameraState.Position = Vector3.Add(cameraState.Position, new Vector3(1f, 0f, 0f));
                cameraState.Target = Vector3.Add(cameraState.Target, new Vector3(1f, 0f, 0f));
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                cameraState.Position = Vector3.Add(cameraState.Position, new Vector3(0f, -1f, 0f));
                cameraState.Target = Vector3.Add(cameraState.Target, new Vector3(0f, -1f, 0f));
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                cameraState.Position = Vector3.Add(cameraState.Position, new Vector3(0f, 1f, 0f));
                cameraState.Target = Vector3.Add(cameraState.Target, new Vector3(0f, 1f, 0f));
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                cameraState.Target = Vector3.Add(cameraState.Target, new Vector3(-rotationScale, 0f, 0f));
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                cameraState.Target = Vector3.Add(cameraState.Target, new Vector3(rotationScale, 0f, 0f));
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                cameraState.Target = Vector3.Add(cameraState.Target, new Vector3(0f, -rotationScale, 0f));
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                cameraState.Target = Vector3.Add(cameraState.Target, new Vector3(0f, rotationScale, 0f));
            }
            if (keyboardState.IsKeyDown(Keys.OemPlus))
            {
                cameraState.Position = Vector3.Add(cameraState.Position, new Vector3(0f, 0f, 20f));
            }
            if (keyboardState.IsKeyDown(Keys.OemMinus))
            {
                cameraState.Position = Vector3.Add(cameraState.Position, new Vector3(0f, 0f, -20f));
            }

            cameraState.RefreshViewMatrix();
        }

        public void SetCameraState(CameraState newCameraState)
        {
            cameraState = newCameraState;
        }

        public BasicEffect UpdateBasicEffect(BasicEffect basicEffect)
        {
            basicEffect.Projection = cameraState.ProjectionMatrix;
            basicEffect.View = cameraState.ViewMatrix;
            basicEffect.World = cameraState.WorldMatrix;

            return basicEffect;
        }
    }