﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_spel
{
    class Player : Movingobject
    {

       
        //konstruktur för att skapa objektet 

        public Player(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y, speedX, speedY) 
        {
         
        }

        public void Update (GameWindow window)
        {
            KeyboardState keyboardState = Keyboard.GetState();


<<<<<<< HEAD
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                speed.X = 1;
                speed.Y = 0;
            }
            if (keyboardState.IsKeyDown(Keys.Left)) 
            {
                speed.X = -1;
                speed.Y = 0;
            }
            if(keyboardState.IsKeyDown(Keys.Up))
            {
                speed.X = 0;
                speed.Y = -1;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                speed.X = 0;
                speed.Y = 1;
            }
            vector += speed;

            /*            if (vector.X <= window.ClientBounds.Width - texture.Width && vector.X >= 0)
                        {
                        }

                        if (vector.Y <= window.ClientBounds.Height - texture.Height && vector.Y >= 0)
                        {
                            if (keyboardState.IsKeyDown(Keys.Down)) vector.Y += speed.Y;
                            if (keyboardState.IsKeyDown(Keys.Up)) vector.Y -= speed.Y;
                        }
                        */
=======
            if (vector.X <= window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Right)) vector.X += speed.X;

                if (keyboardState.IsKeyDown(Keys.Left)) vector.X -= speed.X;
            }

            if (vector.Y <= window.ClientBounds.Height - texture.Height && vector.Y >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Down)) vector.Y += speed.Y;
                if (keyboardState.IsKeyDown(Keys.Up)) vector.Y -= speed.Y;
            }

>>>>>>> 04ab6ab6f8a56c15aa79f1c6c82f1e815dc2d77b
            if (vector.X < 0)
                vector.X = 0;
            if (vector.X > window.ClientBounds.Width - texture.Width)
                vector.X = window.ClientBounds.Width - texture.Width;

            if (vector.Y < 0)
                vector.Y = 0;
            if (vector.Y > window.ClientBounds.Height - texture.Height)
                vector.Y = window.ClientBounds.Height - texture.Height;

        }
       
        

    }
}
