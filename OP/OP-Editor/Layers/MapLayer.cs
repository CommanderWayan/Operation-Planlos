using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OP_Editor.Layers
{
    class MapLayer
    {
        Point[,] _tiles;
        float _parallaxFactor;

        public MapLayer(int Width, int Height)
        {
            this._tiles = new Point[Width, Height];
        }
        public void setTile(int x, int y)
        {
        }
    }
}
