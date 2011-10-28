using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OP_Editor.Map;

namespace OP_Editor.Layers
{
    class MapLayer
    {
        MapTile[,] _tilemap;
        float _parallaxValueVert;
        float _parallaxValueHorz;

        public MapLayer(int Width, int Height, float ParallaxValueVert, float ParallaxValueHorz)
        {
            this._tilemap = new MapTile[Width, Height];
        }

        public void setTile(int x, int y, MapTile Tile)
        {

        }
        
    }
}
