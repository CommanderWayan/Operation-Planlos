using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OP_Editor.Textures
{    
    public class TextureSheet
    {
        int _spriteWidth;
        int _spriteHeight;
        Image[,] _textureSheet;
		int _xTiles;
		int _yTiles;
		int _tiles;

        public TextureSheet(int SpriteWidth, int SpriteHeight, Image Sheet)
        {
            this._spriteHeight = SpriteHeight;
            this._spriteWidth = SpriteWidth;
            buildArray(Sheet);
        }
        public int Tiles { get { return this._tiles; } }
        public int XTiles { get { return this._xTiles; } }
        public int YTiles { get { return this._yTiles; } }
        public int TileWidth { get { return this._spriteWidth; } }
        public int TileHeight { get { return this._spriteHeight; } }        
        public Image this[int X, int Y] { get { return this._textureSheet[X, Y]; } }

        private void buildArray(Image sheet)
        {
            _xTiles = sheet.Width / _spriteWidth;
            _yTiles = sheet.Height / _spriteHeight;
			_tiles = _xTiles * _yTiles;
            _textureSheet = new Image[_xTiles,_yTiles];
            for (int x = 0; x < _xTiles; x++)
            {
                for (int y = 0; y < _yTiles; y++)
                {
                    _textureSheet[x, y] = (sheet as Bitmap).Clone(new Rectangle(x*_spriteWidth, y*_spriteHeight, _spriteWidth, _spriteHeight), System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                }
            }
        }
		
		
	}
}
