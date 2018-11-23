using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_spel
{
    class Level
    {
        private List<Tile> tiles;

        public Level (ContentManager content, string filename)
        {
            //Ladda grafik
            Texture2D blockGfx = content.Load<Texture2D>("Block");
            Texture2D platformGfx = content.Load<Texture2D>("Platform");
            Texture2D exitGfx = content.Load<Texture2D>("Exit");
            Tile tmpObj;
            tiles = new List<Tile>();

            StreamReader sr = new StreamReader(filename);
            string bana = sr.ReadToEnd();
            sr.Close();

            Vector2 tilePos = new Vector2(0, 0);
            for (int i = 0; i<bana.Length;i++)

            switch (bana[i])
            {
                case '\n';
                        tilePos.Y += 32;
                        tilePos.X = 0;
                        break;
                    case '1':
                        tmpObj = new Tile(blockGfx, tilePos, X, tilePos.Y);
                        tiles.Add(tmpObj);
                        tilePos.X += 40;
                        break;
            }
        }
    }
}
