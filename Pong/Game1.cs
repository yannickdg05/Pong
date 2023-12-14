using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        Texture2D ballTexture, ball2Texture, barTexture;
        Vector2 ballPosition, ball2Position;
        float ballSpeed, ball2Speed;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            ballSpeed = 100f;
            ball2Position = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            ball2Speed = 100f;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
            ball2Texture = Content.Load<Texture2D>("ball2");
            barTexture = Content.Load<Texture2D>("bar");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
            {
                ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 3;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 3;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 3;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * 3;
            }

            if (kstate.IsKeyDown(Keys.W))
            {
                ball2Position.Y -= ball2Speed * (float)gameTime.ElapsedGameTime.TotalSeconds * 2;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                ball2Position.Y += ball2Speed * (float)gameTime.ElapsedGameTime.TotalSeconds * 2;
            }

            if (kstate.IsKeyDown(Keys.A))
            {
                ball2Position.X -= ball2Speed * (float)gameTime.ElapsedGameTime.TotalSeconds * 2;
            }

            if (kstate.IsKeyDown(Keys.D))
            {
                ball2Position.X += ball2Speed * (float)gameTime.ElapsedGameTime.TotalSeconds * 2;
            }

            if (ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
            {
                ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            }
            else if (ballPosition.X < ballTexture.Width / 2)
            {
                ballPosition.X = ballTexture.Width / 2;
            }

            if (ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
            {
                ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
            }
            else if (ballPosition.Y < ballTexture.Height / 2)
            {
                ballPosition.Y = ballTexture.Height / 2;
            }

            if (ball2Position.X > _graphics.PreferredBackBufferWidth - ball2Texture.Width / 2)
            {
                ball2Position.X = _graphics.PreferredBackBufferWidth - ball2Texture.Width / 2;
            }
            else if (ball2Position.X < ball2Texture.Width / 2)
            {
                ball2Position.X = ball2Texture.Width / 2;
            }

            if (ball2Position.Y > _graphics.PreferredBackBufferHeight - ball2Texture.Height / 2)
            {
                ball2Position.Y = _graphics.PreferredBackBufferHeight - ball2Texture.Height / 2;
            }
            else if (ball2Position.Y < ball2Texture.Height / 2)
            {
                ball2Position.Y = ball2Texture.Height / 2;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                ballTexture,
                ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
                );
            _spriteBatch.Draw(
                ball2Texture,
                ball2Position,
                null,
                Color.White,
                0f,
                new Vector2(ball2Texture.Width / 2, ball2Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
                );
            _spriteBatch.Draw(
                barTexture, new Vector2(0, 0), Color.Red);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}