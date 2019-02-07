using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_spel
{
    class Apple : GameObject
    {
        
        //Apple texture och placering axeln X och Y
        public Apple (Texture2D texture, float X, float Y) : base(texture, X, Y)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Reposition(float x, float y)
        {
            vector.X = x;
            vector.Y = y;
        }
    }
}
