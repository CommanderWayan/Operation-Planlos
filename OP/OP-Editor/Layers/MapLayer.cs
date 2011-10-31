using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using OP_Editor.Map;

namespace OP_Editor.Layers
{
    public class MapLayer
    {
        MapTile[,] _tilemap;
        float _parallaxValueVert;
        float _parallaxValueHorz;
        string _name;        

        public MapLayer(string Name, int Width, int Height, float ParallaxValueVert, float ParallaxValueHorz)
        {
            this._tilemap = new MapTile[Width, Height];
            this._parallaxValueVert = ParallaxValueVert;
            this._parallaxValueHorz = ParallaxValueHorz;
            _name = Name;
        }
        //CopyConst
        public MapLayer(MapLayer MapLayer)
        {
            this._name = MapLayer._name;
            this._parallaxValueHorz = MapLayer._parallaxValueHorz;
            this._parallaxValueVert = MapLayer._parallaxValueVert;
            this._tilemap = MapLayer._tilemap;
        }
        public string Name { get { return this._name; } set { this._name = value; } }
        public float ParallaxValueVertical { get { return this._parallaxValueVert; } set { this._parallaxValueVert = value; } }
        public float ParallaxValueHorizontal { get { return this._parallaxValueHorz; } set { this._parallaxValueHorz = value; } }
        public void setTile(int x, int y, MapTile Tile)
        {

        }
        public override string ToString()
        {
            return _tilemap.GetLength(0) + " X " + _tilemap.GetLength(1) + "(H"+_parallaxValueHorz + ",V"+_parallaxValueVert+")" + " - " + _name;
        }
        
    }
}
