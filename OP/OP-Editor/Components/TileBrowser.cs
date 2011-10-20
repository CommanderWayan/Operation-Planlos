using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;  
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OP_Editor.Textures;


namespace OP_Editor.Components
{
    public class TileBrowser : System.Windows.Forms.UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        int _browserWidth;
        int _browserHeight;

        private TextureSheet _textureSheet;

        Point _selectedTile;

        public TileBrowser()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
			this.vScrollBar = new System.Windows.Forms.VScrollBar();
			this.hScrollBar = new System.Windows.Forms.HScrollBar();
			this.SuspendLayout();
			// 
			// vScrollBar
			// 
			this.vScrollBar.Enabled = false;
			this.vScrollBar.Location = new System.Drawing.Point(0, 16);
			this.vScrollBar.Name = "vScrollBar";
			this.vScrollBar.Size = new System.Drawing.Size(16, 500);
			this.vScrollBar.TabIndex = 0;
			this.vScrollBar.ValueChanged += new System.EventHandler(this.scrollBar_ValueChanged);
			// 
			// hScrollBar
			// 
			this.hScrollBar.Enabled = false;
			this.hScrollBar.Location = new System.Drawing.Point(16, 0);
			this.hScrollBar.Name = "hScrollBar";
			this.hScrollBar.Size = new System.Drawing.Size(50, 16);
			this.hScrollBar.TabIndex = 1;
			this.hScrollBar.ValueChanged += new System.EventHandler(this.scrollBar_ValueChanged);
			// 
			// TileBrowser
			// 
			this.Controls.Add(this.vScrollBar);
			this.Controls.Add(this.hScrollBar);
			this.Name = "TileBrowser";
			this.Size = new System.Drawing.Size(476, 426);
			this.Load += new System.EventHandler(this.TileBrowser_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TileBrowser_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileBrowser_MouseDown);
			this.Resize += new System.EventHandler(this.TileBrowser_Resize);
			this.ResumeLayout(false);

        }
        public void setTextureSheet(TextureSheet Ts)
        {
            _textureSheet = Ts;
            if (_textureSheet == null)
            {
                vScrollBar.Enabled = false;
                hScrollBar.Enabled = false;
                Update();
                return;
            }
            //Schauen wir mal wieviele teile wir grad darstellen können
            int columns = _browserWidth / _textureSheet.TileWidth;
            int rows = _browserHeight / _textureSheet.TileHeight;
            //gucken ob das ohne Scrollbars reicht
            if (columns < _textureSheet.XTiles) //reicht nicht von der Breite
            {
                hScrollBar.Enabled = true;
                hScrollBar.Minimum = 0;
                hScrollBar.Maximum = _textureSheet.XTiles - columns;
                hScrollBar.Value = 0;                
            }
            if (rows < _textureSheet.YTiles) //reicht nicht von der Höhe
            {
                vScrollBar.Enabled = true;
                vScrollBar.Minimum = 0;
                vScrollBar.Maximum = _textureSheet.YTiles - rows;
                vScrollBar.Value = 0;
            }
			PaintAll();
            Update();
        }

        //EVENTS
        private void TileBrowser_Load(object sender, System.EventArgs e)
        {

        }
        private void TileBrowser_Resize(object sender, System.EventArgs e)
        {
            vScrollBar.Height = Height;
            hScrollBar.Width = Width;
            _browserHeight = Height - hScrollBar.Width;
            _browserWidth = Width - vScrollBar.Width;            
        }
        private void TileBrowser_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            PaintAll();
        }
        private void PaintAll()
        {
            //Scrollbars überprüfen!
            //Teile in Graphics zeichnen!
            //Selektiertes teil hervorheben!
            //MULTISELSECT?
            if (_textureSheet == null) 
                return;

			//TODO: Flackerfrei zeichnen UND! hinkriegen das der Rahmen weg geht!
            Graphics gfx = CreateGraphics();
			Graphics tempGfx = CreateGraphics();
			gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			tempGfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

			tempGfx.Clear(Color.Transparent);
            for (int x = 0; x < _textureSheet.XTiles; x++)
            {
                for (int y = 0; y < _textureSheet.YTiles; y++)
                {				
					Rectangle cutRec = new Rectangle(x * _textureSheet.TileWidth + vScrollBar.Width,
																	y * _textureSheet.TileHeight + hScrollBar.Height,
																	_textureSheet.TileWidth,
																	_textureSheet.TileHeight);
					tempGfx.DrawImageUnscaledAndClipped(_textureSheet[x, y],cutRec);

					Rectangle drawRec = new Rectangle(x * _textureSheet.TileWidth + vScrollBar.Width,
																	y * _textureSheet.TileHeight + hScrollBar.Height,
																	_textureSheet.TileWidth-1,
																	_textureSheet.TileHeight-1);
					if (_selectedTile == new Point(x, y))
					{
						tempGfx.DrawRectangle(new Pen(Color.Red), drawRec);
					}
                }
            }
			
        }
        private void TileBrowser_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Tile Auswählen
            //übertragen in selectedtile
            if (_textureSheet == null)
                return;
            if (e.Button == MouseButtons.Left)
            {
				_selectedTile.X = (e.X - vScrollBar.Width) / _textureSheet.TileWidth;
				_selectedTile.Y = (e.Y - hScrollBar.Height) / _textureSheet.TileHeight;
				Console.WriteLine("SEL: " + _selectedTile.ToString());
            }
            PaintAll();
        }
        private void scrollBar_ValueChanged(object sender, System.EventArgs e)
        {
            PaintAll();            
        }
    }
}


/*
 * private void Repaint()
		{
			if(tileSet == null) return;
			int cols = browseWidth / tileSet.TileSize;
			int rows = browseHeight / tileSet.TileSize;

			int current = scrollBar.Value * cols;
			
			int currentRow = 0;
			Graphics g = CreateGraphics();
			
			Image tempImg = new Bitmap(tileSet.TileSize, tileSet.TileSize);
			Graphics tempg = Graphics.FromImage(tempImg);
			

			do
			{
				
				for(int x = 0; x < cols; x++)
				{
					if(current >= tileSet.TileCount) break;
					tempg.Clear(Color.Black);
					tempg.DrawImage(tileSet[current], 0, 0);
					g.DrawImageUnscaled(tempImg, x * tileSet.TileSize + scrollBar.Width, currentRow * tileSet.TileSize);
					if(current == currentTile && !multiSelect)
					{
						g.DrawRectangle(new Pen(Color.Yellow, 2), x * tileSet.TileSize + scrollBar.Width, currentRow * tileSet.TileSize, tileSet.TileSize-1, tileSet.TileSize-1);
					}

					current++;
				}

				currentRow ++;

			} while ( (current < tileSet.TileCount) && (currentRow <= rows) );

			if(multiSelect)
			{
				int startx = (currentTile % cols) * tileSet.TileSize;
				int starty = (currentTile / cols) * tileSet.TileSize;
				int endx = ((EndTile % cols) + 1) * tileSet.TileSize;
				int endy = ((EndTile / cols) + 1) * tileSet.TileSize;

				g.DrawRectangle(new Pen(Color.Yellow, 2), startx + scrollBar.Width, starty - scrollBar.Value * tileSet.TileSize, endx-startx-1, endy-starty-1);
			}
		}
*/