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


namespace OP_Editor
{
	public partial class frmMain : Form
	{
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
        }

        private void addTextureSheet(FileInfo SheetFile)
        {
            TextureSheetReader tr = new TextureSheetReader();
            TextureSheet ts = tr.loadTextureSheet(SheetFile);			
        }

        private void RefreshPicBoxTiles(object sender, PaintEventArgs e)
        {
            
        }
	}
}
