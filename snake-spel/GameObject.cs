using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_spel
{
    class GameObject
    {
        protected Texture2D texture;
        protected Vector2 vector;
        protected bool isAlive = true;
        //Struktur för att skapa objekt

        public GameObject(Texture2D texture, float X, float Y)
        {
            this.texture = texture;
            this.vector.X = X;
            this.vector.Y = Y;
        }

        //Ritar spelet eller draw bilden på skärmen.

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(vector.X + texture.Width/2, vector.Y + texture.Height/2) , Color.White);
        }

        public float X { get { return vector.X; } }
        public float Y { get { return vector.Y; } }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public Vector2 Position
        {
            get { return vector; }
            set { vector = value; }

        }

        //sida 81
        public bool CheckCollision(GameObject other) //Movingobject?
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height));

            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y), Convert.ToInt32(other.Width), Convert.ToInt32(other.Height));
            return myRect.Intersects(otherRect);
        }
    }
    class Movingobject : GameObject 
    {
        protected Vector2 speed;

      



        public Movingobject(Texture2D texture, float X, float Y, float speedX, float speedY) : base(texture, X, Y)
        {
            this.speed.X = speedX;
            this.speed.Y = speedY;                    
        }

    }




}