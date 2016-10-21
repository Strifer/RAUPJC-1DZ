using GenericList;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Paddle PaddleBottom { get; private set; }

        public Paddle PaddleTop { get; private set; }

        public Ball Ball { get; private set; }

        public Background Background { get; private set; }

        public SoundEffect HitSound { get; private set; }

        public Song Music { get; private set; }

        public List<Wall> Walls { get; set; }
        public List<Wall> Goals { get; set; }

        public IGenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 500,
                PreferredBackBufferHeight = 900
            };
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            var screenBounds = GraphicsDevice.Viewport.Bounds;

            PaddleBottom = new Paddle(GameConstants.PaddleDefaultWidth,
                GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);

            PaddleBottom.X = 250 - PaddleBottom.Width / 2;
            PaddleBottom.Y = 900 - PaddleBottom.Height;

            PaddleTop = new Paddle(GameConstants.PaddleDefaultWidth,
    GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);

            PaddleTop.X = 250 - PaddleTop.Width/2;
            PaddleTop.Y = 0;

            Background = new Background(500, 900);

            Ball = new Ball(GameConstants.DefaultBallSize,
                GameConstants.DefaultInitialBallSpeed,
                GameConstants.DefaultBallBumpSpeedIncreaseFactor,
                GameConstants.DefaultMaxSpeed)
            {
                X = 250,
                Y = 450
            };

            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);

            Walls = new List<Wall>
            {
                new Wall(-GameConstants.WallDefaultSize, 0,
                GameConstants.WallDefaultSize, screenBounds.Height),
                new Wall(screenBounds.Right, 0, GameConstants.WallDefaultSize,
                screenBounds.Height)
            };

            Goals = new List<Wall>
            {
                new Wall(0, screenBounds.Height,
                screenBounds.Width, GameConstants.WallDefaultSize),
                new Wall(screenBounds.Top, -GameConstants.WallDefaultSize,
                screenBounds.Width, GameConstants.WallDefaultSize)
            };

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");
            PaddleBottom.Texture = paddleTexture;
            PaddleTop.Texture = paddleTexture;
            Ball.Texture = Content.Load<Texture2D>("ball");
            Background.Texture = Content.Load<Texture2D>("background");

            HitSound = Content.Load<SoundEffect>("hit");

            // Music = Content.Load<Song>("mm");
            // MediaPlayer.IsRepeating = true;
            // MediaPlayer.Play(Music);
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var touchState = Keyboard.GetState();

            if (touchState.IsKeyDown(Keys.Left)) 
            {
                PaddleBottom.X = PaddleBottom.X - (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.Right))
            {
                PaddleBottom.X = PaddleBottom.X + (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }

            if (touchState.IsKeyDown(Keys.A))
            {
                PaddleTop.X = PaddleTop.X - (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.D))
            {
                PaddleTop.X = PaddleTop.X + (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            PaddleBottom.X = MathHelper.Clamp(PaddleBottom.X, 0, 500 -PaddleBottom.Width);
            PaddleTop.X = MathHelper.Clamp(PaddleTop.X, 0, 500 - PaddleTop.Width);

            if (Walls.Any(w => CollisionDetector.Overlaps(Ball, w)))
            {
                Ball.Direction *= Direction.SW;
                Ball.incrementSpeed();
            }

            if (Goals.Any(w=> CollisionDetector.Overlaps(Ball, w)))
            {
                Ball.X = 250;
                Ball.Y = 450;
                Ball.Speed = GameConstants.DefaultInitialBallSpeed;
                HitSound.Play();
            }

            if ((CollisionDetector.Overlaps(Ball, PaddleTop) && Ball.Direction.Y < 0) || (CollisionDetector.Overlaps(Ball, PaddleBottom) && Ball.Direction.Y > 0) )
            {
                Ball.Direction *= Direction.NE;
                Ball.incrementSpeed();
            }

            var ballPositionState = Ball.Direction * (float)(gameTime.ElapsedGameTime.TotalMilliseconds * Ball.Speed);
            Direction d = Ball.Direction;
            Ball.X += ballPositionState.X;
            Ball.Y += ballPositionState.Y;

            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (Sprite s in SpritesForDrawList)
            {
                s.DrawSpriteOnScreen(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
