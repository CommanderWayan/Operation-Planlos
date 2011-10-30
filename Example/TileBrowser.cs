using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace TileTest
{
	/// <summary>
	/// Summary description for TileBrowser.
	/// </summary>
	public class TileBrowser : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		int currentTile = 0;
		int endTile = 0;
		bool multiSelect = false;

		public TileBrowser()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.scrollBar = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// scrollBar
			// 
			this.scrollBar.Location = new System.Drawing.Point(0, 0);
			this.scrollBar.Name = "scrollBar";
			this.scrollBar.Size = new System.Drawing.Size(16, 288);
			this.scrollBar.TabIndex = 0;
			this.scrollBar.ValueChanged += new System.EventHandler(this.scrollBar_ValueChanged);
			// 
			// TileBrowser
			// 
			this.Controls.Add(this.scrollBar);
			this.Name = "TileBrowser";
			this.Size = new System.Drawing.Size(488, 456);
			this.Resize += new System.EventHandler(this.TileBrowser_Resize);
			this.Load += new System.EventHandler(this.TileBrowser_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TileBrowser_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileBrowser_MouseDown);
			this.ResumeLayout(false);

		}
		#endregion

		private void TileBrowser_Load(object sender, System.EventArgs e)
		{
		
		}

		private System.Windows.Forms.VScrollBar scrollBar;

		TileSet tileSet;

		public void SetTileSet(TileSet ts)
		{
			tileSet = ts;
			if(tileSet == null) 
			{
				scrollBar.Enabled = false;
				Update();
				return;
			}

			
			// Figure out how many rows and columns of tiles we can display at once
			int cols = browseWidth / tileSet.TileSize;
			int rows = browseHeight / tileSet.TileSize;
			if(rows * cols < tileSet.TileCount) // If we don't have enough room without scrolling
			{
				scrollBar.Enabled = true;
				int rowsNeeded = tileSet.TileCount / cols;
				scrollBar.Minimum = 0;
				scrollBar.Maximum = rowsNeeded - rows;
				scrollBar.Value = 0;
			}
			
			


			Update();
		}

		private void TileBrowser_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Repaint();
		}

		private void Repaint()
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

		int browseWidth;
		int browseHeight;


		private void TileBrowser_Resize(object sender, System.EventArgs e)
		{
			scrollBar.Height = Height;
			browseHeight = Height;
			browseWidth = Width - scrollBar.Width;
			//scrollBar.Enabled = false;
		}

		private void scrollBar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			
		}

		private void scrollBar_ValueChanged(object sender, System.EventArgs e)
		{
			Repaint();
		}

		private void TileBrowser_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int cols = browseWidth / tileSet.TileSize;
			int rows = browseHeight / tileSet.TileSize;

			int actualWidth = cols * tileSet.TileSize;

			if(e.X > actualWidth) return;

			if(e.Button == MouseButtons.Left)
			{
				currentTile = ((e.X - scrollBar.Width) / tileSet.TileSize) + (e.Y / tileSet.TileSize) * cols + scrollBar.Value * cols;
				multiSelect = false;
			} 
			else if(e.Button == MouseButtons.Right)
			{
				endTile = ((e.X - scrollBar.Width) / tileSet.TileSize) + (e.Y / tileSet.TileSize) * cols + scrollBar.Value * cols;
				multiSelect = true;
			}

			Repaint();
			
		}

		public int CurrentTile
		{
			get
			{
				return currentTile;
			}
		}

		public int EndTile
		{
			get
			{
				return endTile;
			}

		}

		public bool MultiSelected
		{
			get
			{
				return multiSelect;
			}
		}

				
	}
}
