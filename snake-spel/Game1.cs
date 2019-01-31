using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

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
       

        Player player;


        //Apple 
        Apple apple;
        Texture2D AppleSprite;


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

            // TODO: use this.Content to load your game content here
            player = new Player(Content.Load<Texture2D>("snake1"), 200, 200, 0f, 0f);

            AppleSprite = Content.Load<Texture2D>("RedApple");
            apple = new Apple(AppleSprite, -100, -100);
            AddApple();
        }
        

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected void AddApple()
        {
            Random random = new Random();

            int rndX = random.Next(0, Window.ClientBounds.Width - AppleSprite.Width);
            int rndY = random.Next(0, Window.ClientBounds.Height - AppleSprite.Height);

            apple.Reposition(rndX, rndY);

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

            //Apple ska uppstå slumpmässigt
           
            

            //foreach (Apple ap in appleApple.ToList())
            //{
            //    if (ap.IsAlive)
            //    {
            //        //ap.Update(gameTime);

            //        if (ap.CheckCollision(player))
            //        {
            //            appleApple.Remove(ap);
            //            player.Points++;
            //        }
            //    }
            //    else
            //        appleApple.Remove(ap);

            //}

            player.Update(Window);
            
            if(player.CheckCollision(apple))
            {
                player.Points++;
                AddApple();
            }
            
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
            apple.Draw(spriteBatch);
            //foreach (Apple ap in appleApple)
            //    ap.Draw(spriteBatch);
            

            spriteBatch.End();
            base.Draw(gameTime);
            
        }
    }
}
