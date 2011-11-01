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
    //TODO: setzen der tileabmessungen wenn tilesheet oder map erstellt werden
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
            Dialogs.dlgNewLayer dlgNewMap = new Dialogs.dlgNewLayer(Dialogs.dlgNewLayer.NewType.Map);
            if (dlgNewMap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Neue Map erstellen
                mapViewer.SetMap(new Map.Map(dlgNewMap.Label, dlgNewMap.MapWidth, dlgNewMap.MapHeight, dlgNewMap.ParaVert, dlgNewMap.ParaHorz));
                listBox_Layers.DataSource = mapViewer.CurrentMap.Layers;                  
            }
        }
        private void button_AddLayer_Click(object sender, EventArgs e)
        {
            if (mapViewer.CurrentMap == null)
            {
                MessageBox.Show("You cannot add a layer without generating a map first!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            else
            {
                Dialogs.dlgNewLayer dlgNewLayer = new Dialogs.dlgNewLayer(Dialogs.dlgNewLayer.NewType.Layer);
                if (dlgNewLayer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    mapViewer.CurrentMap.AddLayer(dlgNewLayer.Label, dlgNewLayer.MapWidth, dlgNewLayer.MapHeight, dlgNewLayer.ParaVert, dlgNewLayer.ParaHorz);
                    refreshLayersDisplay();
                }
            }
        }
        private void button_RemoveLayer_Click(object sender, EventArgs e)
        {
            if (listBox_Layers.SelectedIndex != -1)
            {
                Console.WriteLine(listBox_Layers.SelectedIndex);
                mapViewer.CurrentMap.RemoveLayer(listBox_Layers.SelectedIndex);
                refreshLayersDisplay();
            }
        }
        private void addTextureSheet(FileInfo SheetFile)
        {
            if (mapViewer.CurrentMap != null)
            {
                int? tilewidth;
                int? tileheight;
                TextureSheetReader tr = new TextureSheetReader();
                TextureSheet ts = tr.loadTextureSheet(SheetFile, out tilewidth, out tileheight);
                if (tileheight != null && tilewidth != null)
                {
                    if (mapViewer.CurrentMap.TileHeight == -1 && mapViewer.CurrentMap.TileWidth == -1)
                    {
                        //erstes laden - is noch kein texturesheet da!
                        tileBrowser1.setTextureSheet(ts, SheetFile.Name);
                        mapViewer.CurrentMap.SetTileDimensions((int)tilewidth, (int)tileheight);
                    }
                    else
                    {
                        if (mapViewer.CurrentMap.TileHeight == tileheight)
                        {
                            if (mapViewer.CurrentMap.TileWidth == tilewidth)
                            {
                                tileBrowser1.setTextureSheet(ts, SheetFile.Name);
                                mapViewer.CurrentMap.SetTileDimensions((int)tilewidth, (int)tileheight);
                            }
                            else
                                MessageBox.Show("The width of the loaded tiles does not match previously loaded texturesheet dimensions!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("The height of the loaded tiles does not match previously loaded texturesheet dimensions!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("You cannot add a Texturesheet without generating a map first!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void button_LayerUp_Click(object sender, EventArgs e)
        {
            mapViewer.CurrentMap.MoveLayerUp(listBox_Layers.SelectedIndex);
            if ((listBox_Layers.SelectedIndex < listBox_Layers.Items.Count - 1) && listBox_Layers.SelectedIndex > 0)
                listBox_Layers.SelectedIndex++;
            refreshLayersDisplay();
        }

        private void button_LayerDown_Click(object sender, EventArgs e)
        {
            mapViewer.CurrentMap.MoveLayerDown(listBox_Layers.SelectedIndex);
            if (listBox_Layers.SelectedIndex > 1) 
                listBox_Layers.SelectedIndex--;
            refreshLayersDisplay();
        }

        private void refreshLayersDisplay()
        {
            ((CurrencyManager)listBox_Layers.BindingContext[mapViewer.CurrentMap.Layers]).Refresh();
        }

        private void button_EditLayer_Click(object sender, EventArgs e)
        {
            //TODO: Layer editierbar machen
            /*
            Dialogs.dlgNewLayer dlgNewLayer = new Dialogs.dlgNewLayer(Dialogs.dlgNewLayer.NewType.EditLayer);
            
            if (dlgNewLayer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
             * */
        }

        

        
        

                     
	}
}
