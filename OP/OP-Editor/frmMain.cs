using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OP_Editor.Textures;
using OP_Editor.ContentReaders;
using OP_Editor.Viewers;

namespace OP_Editor
{
	public partial class frmMain : Form
	{
		EditorTilePainter TilePainter;
		public frmMain()
		{
			InitializeComponent();			
		}

        private void addTexturesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogTextureSheet.InitialDirectory = Application.ExecutablePath;
            if (openFileDialogTextureSheet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addTextureSheet(new FileInfo(openFileDialogTextureSheet.FileName));
            }
			if (TilePainter != null)
				TilePainter.DrawTiles();
        }

        private void addTextureSheet(FileInfo SheetFile)
        {
            TextureSheetReader tr = new TextureSheetReader();
            TextureSheet ts = tr.loadTextureSheet(SheetFile);
			TilePainter = new EditorTilePainter(this.panelEditorTiles, ts);
        }

		private void RefreshPicBoxTiles(object sender, PaintEventArgs e)
		{
			if(TilePainter != null)
				TilePainter.DrawTiles();
		}
	}
}
