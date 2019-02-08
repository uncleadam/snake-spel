using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_spel
{
    class Player : GameObject
    {

        KeyboardState oldKs;

        float angle = 0;
        int points;

        //lista på ormens olika delar
        List<Body> bodyParts;

        Vector2 speed = new Vector2(32, 0);
        //Används för att sinka ned hastigheten till något lämpligt
        int game_speed = 256; //Ändra detta värde när du äter ett äpple för att låta spelet gå fortare.
        int move_time;


        //konstruktur för att skapa objektet 
        public Player(Texture2D image, float x, float y, int length) : base(image, x, y)
        {
            bodyParts = new List<Body>();

            int antBodyParts = 5;

            for (int i = 1; i <= length; i++)
            {
                Body temp = new Body(image, X - i * 32, y);
                bodyParts.Add(temp);
            }
        }


       
       

        //Styrningen, hastighet och riktning. 
        public void Update (GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();


            if (keyboardState.IsKeyDown(Keys.Right))
            {
                speed.X = 32;
                speed.Y = 0;
                angle = (float)Math.PI;

            }
            if (keyboardState.IsKeyDown(Keys.Left)) 
            {
                speed.X = -32;
                speed.Y = 0;
                angle = 0;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                speed.X = 0;
                speed.Y = -32;
                angle = (float)Math.PI / 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                speed.X = 0;
                speed.Y = 32;
                angle = (float)Math.PI * 3 / 2f;

            }
            //Räknar ned tiden tills den ska flyttas
            move_time -= gameTime.ElapsedGameTime.Milliseconds;
            if (move_time <= 0)
            {
                //Gör först en imaginär flytt
                Vector2 newPos = vector + speed;
                //Spara den gamla positionen
                Vector2 oldPos = vector;
                //Flytta fram huvudet
                vector = newPos;
                //Använd den gamla positionen som ny position för nästa kroppsdel.
                newPos = oldPos;

                //Flyttar alla svansdelar
                foreach (Body p in bodyParts)
                {
                    oldPos = new Vector2(p.X, p.Y);
                    p.MoveTo(newPos);
                    newPos = oldPos;
                }
                move_time = game_speed;

                oldKs = keyboardState;


            }
        }
     
           //Ritar ut rotationen 90 grader och hastighet
        public override void Draw(SpriteBatch spriteBatch)
        {
            // huvudets rotation men den funkar inte helt 
            spriteBatch.Draw(texture, vector+new Vector2(16,16), null, Color.White, angle + (float)Math.PI / 2,
                new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, 0);

            foreach (Body p in bodyParts)
            {
                p.Draw(spriteBatch);
            }
        }

        public int Points { get { return points; } set { points = value; } }

    }



}

