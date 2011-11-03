using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using OP_Editor.Map;
using System.Drawing;

namespace OP_Editor.Components
{
    public partial class MapViewer : System.Windows.Forms.UserControl
    {
        private int _tileHeight;
        private int _tileWidth;
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
            if (_map == null)
                return;
            if (_grid)
            {
                //TODO: Layer zentrieren (an richtiger stelle zeichnen!) (In abhängigkeit von breitestem layer)
                if (_map.TileHeight == -1 || _map.TileWidth == -1)
                    return;
                paintGrid();
            }
            Console.WriteLine(_map.ActiveLayer);
            //Map malen
            //Anm: Lauf durch alle layer - gucke nach breitestem - richte dich danach!
            //
        }
        private void paintGrid()
        {            
            Graphics gfx = CreateGraphics();
            Bitmap tempBmp = new Bitmap(_map.TileWidth * _map.Layers[_map.ActiveLayer].Width, _map.TileHeight * _map.Layers[_map.ActiveLayer].Height);
            Graphics tempGfx = Graphics.FromImage(tempBmp);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            tempGfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            tempGfx.Clear(this.BackColor);

            _map.DrawGrid(tempGfx);            
            gfx.DrawImage(tempBmp, 0 , 0 );
         
        }
        public void SetMap(Map.Map Map)
        {
            this._map = Map;            
        }
        public Map.Map CurrentMap { get { return this._map; } }
        public bool Grid 
        { 
            get { return this._grid; } 
            set 
            { 
                this._grid = value;
                PaintAll();
            } 
        }
    }
}
