using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public interface ICamera
{
    CameraState GetCameraState();
    void SetCameraState(CameraState newCameraState);
    void Update(KeyboardState keyboardState, MouseState mouseState);
    BasicEffect UpdateBasicEffect(BasicEffect basicEffect);
}