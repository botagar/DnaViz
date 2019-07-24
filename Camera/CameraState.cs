using Microsoft.Xna.Framework;

public class CameraState
    {
        public Vector3 Target { get; set; }
        public Vector3 Position { get; set; }
        public Matrix ProjectionMatrix { get; set; }
        public Matrix ViewMatrix { get; set; }
        public Matrix WorldMatrix { get; set; }

        public CameraState() : this(Vector3.Zero, new Vector3(0f, -10f, -10f), 45f, 0.5f, 1f, 9999f)
        {
        }

        public CameraState(Vector3 target, Vector3 position, float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            Target = target;
            Position = position;
            ProjectionMatrix = 
                Matrix.CreatePerspectiveFieldOfView(
                    fieldOfView: MathHelper.ToRadians(fieldOfView),
                    aspectRatio: aspectRatio,
                    nearPlaneDistance: nearPlaneDistance,
                    farPlaneDistance: farPlaneDistance);
            ViewMatrix = Matrix.CreateLookAt(position, target, Vector3.UnitZ); // Z up
            WorldMatrix = Matrix.CreateWorld(target, Vector3.Forward, Vector3.Up);
        }

        public void RefreshViewMatrix()
        {
            ViewMatrix = Matrix.CreateLookAt(Position, Target, Vector3.Up);
        }
    }