using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DNA_Viz
{
    public class DnaVisualiser : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BasicEffect basicEffect;
        ICamera camera;
        VertexBuffer vertexBuffer;
        MouseState previousMouseState;
        KeyboardState previousKeyboardState;

        //Debug output on screen
        private SpriteFont font;
        private Performance performance;
        private int mouseX = 0;
        private int mouseY = 0;
        private Vector2 screenCenter;

        Dna dna;

        public DnaVisualiser()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            var width = 1000;
            var depth = 1000;
            var resolution = 2;
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), width * depth * resolution * resolution * 6, BufferUsage.WriteOnly);

            camera = camera ?? new EditorCamera(graphics.GraphicsDevice);

            //BasicEffect
            basicEffect = new BasicEffect(GraphicsDevice)
            {
                Alpha = 1f,
                VertexColorEnabled = true,
                LightingEnabled = false,
                TextureEnabled = false
            };

            dna = new Dna(graphics.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("File");
            performance = new Performance();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState state = Mouse.GetState();
            mouseX = state.X;
            mouseY = state.Y;

            camera.Update(Keyboard.GetState(), Mouse.GetState());

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            performance.FrameUpdated(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Texture2D rect = new Texture2D(GraphicsDevice, 1, 1);
            rect.SetData(new[] { Color.White });

            spriteBatch.Begin();

            spriteBatch.Draw(rect, new Rectangle(0, 0, 150, 150), Color.Black);
            if (!float.IsInfinity(performance.CurrentInstantaneousFrameRate()))
                spriteBatch.DrawString(font, string.Format("FPS = {0}", performance.CurrentInstantaneousFrameRate().ToString()), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, string.Format("Tris = {0:n0}", vertexBuffer.VertexCount / 3), new Vector2(10, 25), Color.White);
            spriteBatch.DrawString(font, string.Format("Cursor :: x={0} y={1}", mouseX, mouseY), new Vector2(10, 40), Color.White);
            spriteBatch.DrawString(font, string.Format("Cursor :: dx={0} dy={1}", previousMouseState.X - mouseX, previousMouseState.Y - mouseY), new Vector2(10, 55), Color.White);

            spriteBatch.End();

            Mouse.SetPosition((int)screenCenter.X, (int)screenCenter.Y);
            previousMouseState = Mouse.GetState();

            base.Draw(gameTime);
        }
    }
}
