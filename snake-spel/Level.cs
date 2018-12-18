using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_spel
{
    class Level
    {
        private List<GameObject> tiles;

        public Level (ContentManager content, string filename)
        {
            //Ladda grafik
            Texture2D tile1Gfx = content.Load<Texture2D>("ruta1");
            Texture2D tile2Gfx = content.Load<Texture2D>("ruta2");
            //Texture2D exitGfx = content.Load<Texture2D>("Exit");
            GameObject tmpObj;
            tiles = new List<GameObject>();

            StreamReader sr = new StreamReader(filename);
            string bana = sr.ReadToEnd();
            sr.Close();

            Vector2 tilePos = new Vector2(0, 0);
            for (int i = 0; i<bana.Length;i++)
            { 

                switch (bana[i])
                {
                    case '\n':
                        tilePos.Y += 32;
                        tilePos.X = 0;
                        break;
                    case '0':
                        tmpObj = new GameObject(tile1Gfx, tilePos.X, tilePos.Y);
                        tiles.Add(tmpObj);
                        tilePos.X += 32;
                        break;
                    case '1':
                        tmpObj = new GameObject(tile2Gfx, tilePos.X, tilePos.Y);
                        tiles.Add(tmpObj);
                        tilePos.X += 32;
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GameObject t in tiles)
            {
                t.Draw(spriteBatch);
            }
        }
    }
}
