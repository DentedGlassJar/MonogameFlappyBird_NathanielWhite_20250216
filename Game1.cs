using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameFlappyBird_NathanielWhite_20250216
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D birdSprite;
        private Vector2 birdPosition;

        private Texture2D wallSprite;
        private Vector2 wallPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            birdSprite = Content.Load<Texture2D>("FlappyBird");
            birdPosition = Vector2.Zero;

            wallSprite = Content.Load<Texture2D>("Blockade");
            wallPosition = new Vector2(750, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // Updates for the walls
            wallPosition.X -= 10;
            
            if (wallPosition.X == 0)
            {
                wallPosition.X = 750;
            }
            
            // Updates for the bird
            birdPosition.Y += 10;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                birdPosition.Y -= 15;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(wallSprite, wallPosition, Color.White);
            _spriteBatch.Draw(birdSprite, birdPosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
