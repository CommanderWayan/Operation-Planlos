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
        bool _repeating = false;

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
        public bool Repeating { get { return this._repeating; } set { this._repeating = value; } }
        public string Name { get { return this._name; } set { this._name = value; } }
        public float ParallaxValueVertical { get { return this._parallaxValueVert; } set { this._parallaxValueVert = value; } }
        public float ParallaxValueHorizontal { get { return this._parallaxValueHorz; } set { this._parallaxValueHorz = value; } }
        public int Width
        {
            get { return this._tilemap.GetLength(0); }
            set
            {
                if (value != _tilemap.GetLength(0))
                {
                    MapTile[,] tempTilemap = new MapTile[value, _tilemap.GetLength(1)];
                    //Altes Array kopieren
                    if (tempTilemap.GetLength(0) > _tilemap.GetLength(0)) //Passt rein - neue Tilemap ist größer
                    {
                        Array.Copy(_tilemap, tempTilemap, _tilemap.Length);
                    }
                    else // neue Tilemap ist schmaler
                    {
                        Array.Copy(_tilemap, tempTilemap, tempTilemap.Length);
                    }
                    _tilemap = tempTilemap;
                }
            }
        }
        public int Height
        {
            get { return this._tilemap.GetLength(1); }
            set
            {
                if (value != _tilemap.GetLength(1))
                {
                    MapTile[,] tempTilemap = new MapTile[_tilemap.GetLength(0), value];
                    //Altes Array kopieren
                    if (tempTilemap.GetLength(1) > _tilemap.GetLength(1)) //Passt rein - neue Tilemap ist größer
                    {
                        Array.Copy(_tilemap, tempTilemap, _tilemap.Length);
                    }
                    else // neue Tilemap ist schmaler
                    {
                        Array.Copy(_tilemap, tempTilemap, tempTilemap.Length);
                    }
                    _tilemap = tempTilemap;
                }
            }
        }
        public void setTile(int x, int y, MapTile Tile)
        {

        }
        public override string ToString()
        {
            return _tilemap.GetLength(0) + " X " + _tilemap.GetLength(1) + "(H" + _parallaxValueHorz + ",V" + _parallaxValueVert + ")" + " - " + _name;
        }

        public void Draw(Graphics gfx)
        {
        }
        public void DrawGrid(Graphics gfx, int TileWidth, int TileHeight)
        {
            for (int x = 0; x < _tilemap.GetLength(0); x++)
            {
                for (int y = 0; y < _tilemap.GetLength(1); y++)
                {
                    gfx.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(128, 0, 0, 255))), new Rectangle(x * TileWidth, y * TileHeight, TileWidth - 1, TileHeight - 1));
                }
            }
        }
    }
}
