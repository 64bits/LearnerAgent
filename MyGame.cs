using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LearnerAgent
{
    
    public class MyGame : Game
    {
        // Temporary variables for testing
        public static int X = 0;
        public static int Y = 0;
        
        // Set the camera scale
        private float SPRITE_SCALE = 0.25f;
        
        private Utilities _agentUtilities;
        private Graph _knowledgeGraph;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _agent;

        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Create the graph
            _knowledgeGraph = new Graph();
            _agentUtilities = new Utilities(_knowledgeGraph);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _agent = Content.Load<Texture2D>("circle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Call the various utility functions
            _agentUtilities.GenerateNoise();
            _agentUtilities.RecalculateAttention();
            _agentUtilities.CreateConnections();
            _agentUtilities.WidenPipes();
            _agentUtilities.ConstrictPipes();
            _agentUtilities.MoveAgent();
            _agentUtilities.PropagateAttention();
            _agentUtilities.DiminishAttention();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var transform = Matrix.CreateTranslation(new Vector3(0, 0, 0))* // camera position
                            Matrix.CreateRotationZ(0)* // camera rotation, default 0
                            Matrix.CreateScale(new Vector3(SPRITE_SCALE, SPRITE_SCALE, 1))* // Zoom default 1
                            Matrix.CreateTranslation(
                                new Vector3(
                                    GraphicsDevice.Viewport.Width*0.5f,
                                    GraphicsDevice.Viewport.Height*0.5f, 0)); // Device from DeviceManager, center camera to given position
            _spriteBatch.Begin( // SpriteBatch variable
                SpriteSortMode.BackToFront, // Sprite sort mode - not related
                BlendState.NonPremultiplied, // BelndState - not related
                null,
                null,
                null,
                null,
                transform);
            _spriteBatch.Draw(_agent, new Rectangle(X, Y, 128, 128), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}