using GenericList;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
            PaddleBottom.Y = 0;

            PaddleTop = new Paddle(GameConstants.PaddleDefaultWidth,
    GameConstants.PaddleDefaulHeight, GameConstants.PaddleDefaulSpeed);

            PaddleTop.X = 250 - PaddleTop.Width/2;
            PaddleTop.Y = 900-PaddleTop.Height;

            Background = new Background(500, 900);

            Ball = new Ball(GameConstants.DefaultBallSize,
                GameConstants.DefaultInitialBallSpeed,
                GameConstants.DefaultBallBumpSpeedIncreaseFactor)
            {
                X = 250,
                Y = 450
            };

            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);

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

            Music = Content.Load<Song>("mm");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Music);
            
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

            // TODO: Add your update logic here

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
