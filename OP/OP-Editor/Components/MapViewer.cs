using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OP_Editor.Map;

namespace OP_Editor.Components
{
    public partial class MapViewer : System.Windows.Forms.UserControl
    {
        private int _tileHeight = 10;
        private int _tileWidth = 10;
        private Map.Map _map;
        private bool _grid = false;

        public MapViewer()
        {
            InitializeComponent();
        }
        private void MapViewer_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            PaintAll();
        }
        private void PaintAll()
        {
            if (_grid)
                paintGrid();
            //Map malen
            //Anm: Lauf durch alle layer - gucke nach breitestem - richte dich danach!
            //
        }
        private void paintGrid()
        {
            /*
            Graphics gfx = CreateGraphics();
            Bitmap tempBmp = new Bitmap(_textureSheet.TileWidth * _textureSheet.XTiles, _textureSheet.TileHeight * _textureSheet.YTiles);
            Graphics tempGfx = Graphics.FromImage(tempBmp);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            tempGfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            tempGfx.Clear(this.BackColor);

            gfx.DrawImage(tempBmp, 0 + vScrollBar.Width, 0 + hScrollBar.Height);
             * */
        }
        public void SetMap(Map.Map Map)
        {
            this._map = Map;
        }
        public Map.Map CurrentMap { get { return this._map; } }
        public bool Grid { get { return this._grid; } set { this._grid = value; } }
    }
}
