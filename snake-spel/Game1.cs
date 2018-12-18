using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace snake_spel
{
    /// <summary>
    /// Ett program utvecklat av Ibbe och Adam 2018-19 i kursen programmering 2.
    /// Ibbes branch.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
       

        int levelNo;
        bool victory;
        Level level;


        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            //WriteToFile();
            levelNo = 0;
            victory = true;

            base.Initialize();
        }

        public void WriteToFile()
        {
            
            StreamWriter sw = new StreamWriter("lvl1.txt");
            sw.WriteLine("010101");
            sw.WriteLine("101010");
            sw.WriteLine("010101");
            sw.WriteLine("101010");
            sw.WriteLine("010101");
            sw.WriteLine("101010");
            sw.WriteLine("010101");
            sw.WriteLine("101010");

            sw.Close();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player = new Player(Content.Load<Texture2D>("snake1"), 200, 200, 0f, 0f);
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
            if (victory)
            {
                levelNo++;
                level = new Level(Content, "lvl" + levelNo + ".txt");
                victory = false;
            }


            player.Update(Window);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            //spriteBatch.Draw(gfx, position, Color.White);
            player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);            
        }
    }
}