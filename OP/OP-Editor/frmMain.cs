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
			this.DoubleBuffered = true;
		}

        private void addTexturesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogTextureSheet.InitialDirectory = Application.ExecutablePath;
            if (openFileDialogTextureSheet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addTextureSheet(new FileInfo(openFileDialogTextureSheet.FileName));
            }			
        }
        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialogs.dlgNewMap dlgNewMap = new Dialogs.dlgNewMap();
            if (dlgNewMap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Neue Map erstellen
                mapViewer.SetMap(new Map.Map(dlgNewMap.MapWidth, dlgNewMap.MapHeight, dlgNewMap.ParaVert, dlgNewMap.ParaHorz));
                setLayerControl(mapViewer.CurrentMap.LayerCount);                
            }
            else
            {
                //Nix
            }

        }
        private void setLayerControl(int LayerCount)
        {
            this.layerChooser.Maximum = LayerCount;
            this.label_LayerCount.Text = "/ " + LayerCount.ToString();
        }
        private void addTextureSheet(FileInfo SheetFile)
        {
            TextureSheetReader tr = new TextureSheetReader();
            TextureSheet ts = tr.loadTextureSheet(SheetFile);
            tileBrowser1.setTextureSheet(ts,SheetFile.Name);
        }

                     
	}
}
