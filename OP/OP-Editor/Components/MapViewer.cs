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
        private int _tileHeight;
        private int _tileWidth;
        private Map.Map _map;

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
            //Map malen
        }
        public void SetMap(Map.Map Map)
        {
            this._map = Map;
        }
        public Map.Map CurrentMap { get { return this._map; } }
	}
}
