using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OP_Editor.Map
{

    public class MapTile
    {
        Point _textureSheetTile;
        Textures.TextureSheet _usedTextureSheet;

        public MapTile(int XSheetCoordinate, int YSheetCoordinate, ref Textures.TextureSheet UsedTextureSheet)
        {
            _textureSheetTile.X = XSheetCoordinate;
            _textureSheetTile.Y = YSheetCoordinate;
            _usedTextureSheet = UsedTextureSheet;
        }
        public void draw()
        {
        }
    }
}
