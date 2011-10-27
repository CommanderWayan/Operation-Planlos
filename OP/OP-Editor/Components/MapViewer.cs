using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OP_Editor.Components
{
	public partial class MapViewer : System.Windows.Forms.UserControl
	{
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
        public void SetMap()
        {
        }
	}
}
