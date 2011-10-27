using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OP_Editor.Layers
{
    class MapLayer
    {
        Point[,] _tilemap;
        float _parallaxFactor;

        public MapLayer(int Width, int Height)
        {
            this._tilemap = new Point[Width, Height];
        }
        public void setTile(int x, int y)
        {

        }
    }
}
