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

        //Struktur för att skapa objekt

        public GameObject(Texture2D texture, float X, float Y)
        {
            this.texture = texture;
            this.vector.X = X;
            this.vector.Y = X;
        }

        //Ritar spelet eller draw bilden på skärmen.

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.Green);
        }

        public float X { get { return vector.X; } }
        public float Y { get { return vector.Y; } }
        public float Width { get { return texture.Width; } }
        public float Height { get { return texture.Height; } }

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
