using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.Cryptography;

namespace MonogameFlappyBird_NathanielWhite_20250216
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D birdSprite;
        private Vector2 birdPosition;
        private Rectangle birdCollision;

        private Texture2D wallSprite;
        private Vector2 wallPosition;
        private Rectangle wallCollision;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            birdSprite = Content.Load<Texture2D>("FlappyBird");
            birdPosition = Vector2.Zero;
            birdCollision = new Rectangle(birdPosition.X, birdPosition.Y, 56, 23);

            wallSprite = Content.Load<Texture2D>("Blockade");
            wallPosition = new Vector2(750, 0);
            wallCollision = new Rectangle(wallPosition.X, wallPosition.Y, 61, 241);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            
            Random rng = new Random();
            int ranInt = rng.Next(0, 4);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Updates for the walls
            wallPosition.X -= 10;
            
            if (wallPosition.X == 0)
            {
                wallPosition.X = 750;

                if (ranInt == 0)
                {
                    wallPosition.Y = 0;
                }

                if (ranInt == 1)
                {
                    wallPosition.Y = 100;
                }

                if (ranInt == 2)
                {
                    wallPosition.Y = 200;
                }

                if (ranInt == 3)
                {
                    wallPosition.Y = 300;
                }
            }
            
            // Updates for the bird
            birdPosition.Y += 10;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                birdPosition.Y -= 15;
            }

            if (birdCollision.Intersects(wallCollision))
            {
                Exit();
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
