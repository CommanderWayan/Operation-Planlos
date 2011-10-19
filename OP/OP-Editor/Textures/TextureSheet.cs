using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OP_Editor.Textures
{    
    class TextureSheet
    {
        int _spriteWidth;
        int _spriteHeight;
        Image[,] _textureSheet;

        public TextureSheet(int SpriteWidth, int SpriteHeight, Image Sheet)
        {
            this._spriteHeight = SpriteHeight;
            this._spriteWidth = SpriteWidth;
            buildArray(Sheet);
        }
        private void buildArray(Image sheet)
        {
            int xTiles = sheet.Width / _spriteWidth;
            int yTiles = sheet.Height / _spriteHeight;
            _textureSheet = new Image[xTiles,yTiles];
            for (int x = 0; x < xTiles; x++)
            {
                for (int y = 0; y < yTiles; y++)
                {
                    _textureSheet[x, y] = (sheet as Bitmap).Clone(new Rectangle(x*_spriteWidth, y*_spriteHeight, _spriteWidth, _spriteHeight), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                }
            }
        }
    }
}
