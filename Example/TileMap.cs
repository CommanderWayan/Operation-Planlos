using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;


namespace TileTest
{
	/// <summary>
	/// Summary description for TileMap.
	/// </summary>
	public class TileMap : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		int[][] map;
		int[][] detailmap;
		int[][] overlaymap;

		bool drawMap = true;
		bool drawDetail = true;
		bool drawOverlay = true;
		
		TileSet tileSet;

		Image backBuff;

		Thread thr;
		bool shouldEnd = false;
		int xOffset = 0;
		int yOffset = 0;


		public TileMap()
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
			// 
			// TileMap
			// 
			this.Name = "TileMap";
			this.Resize += new System.EventHandler(this.TileMap_Resize);
			this.Load += new System.EventHandler(this.TileMap_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TileMap_Paint);

		}
		#endregion

		int[] cycle;

		private void TileMap_Load(object sender, System.EventArgs e)
		{
			cycle = new int[480];
			for(int i = 0; i < 480; i++)
			{
				cycle[i] = i;
			}


			ResizeMap(1, 1);
		}

		public TileMap(TileMap copy)
		{
			CopyMap(copy);
		}

		public void CopyMap(TileMap copy)
		{
			ResizeMap(copy.MapSizeX, copy.MapSizeY);
			this.tileSet = copy.tileSet;
			for(int i = 0; i < 3; i++)
			{
				for(int x = 0; x < MapSizeX; x++)
				{
					for(int y = 0; y < MapSizeY; y++)
					{
						this[i][x][y] = copy[i][x][y];
					}
				}
			}
			drawMap = copy.drawMap;
			drawDetail = copy.drawDetail;
			drawOverlay = copy.drawOverlay;
			xOffset = copy.xOffset;
			yOffset = copy.yOffset;

		}

		public Point GetTileFromPoint(int x, int y)
		{
			Point p = new Point();
            p.X = (x + xOffset)	/ tileSet.TileSize;
			p.Y = (y + yOffset)	/ tileSet.TileSize;
			return p;
		}


		public void SaveMap(string filename)
		{
			BinaryFormatter serializer = new BinaryFormatter();
			System.IO.Stream str = System.IO.File.OpenWrite(filename);
			serializer.Serialize(str, map);
			serializer.Serialize(str, detailmap);
			serializer.Serialize(str, overlaymap);
			str.Close();
		}

		public void LoadMap(string filename)
		{
			BinaryFormatter serializer = new BinaryFormatter();

			int []i = new int[30];
			System.IO.Stream str = System.IO.File.OpenRead(filename);
			map = (int[][])serializer.Deserialize(str);
			detailmap = (int[][])serializer.Deserialize(str);
			overlaymap = (int[][])serializer.Deserialize(str);
			str.Close();
			

		}

		public void ResizeMap(int width, int height)
		{
			map = new int[width][];
			detailmap = new int[width][];
			overlaymap = new int[width][];
			for(int i = 0; i < width; i++)
			{
				map[i] = new int[height];
				detailmap[i] = new int[height];
				overlaymap[i] = new int[height];
				for(int j = 0; j < height; j++)
				{
					map[i][j] = -1;
					detailmap[i][j] = -1;
					overlaymap[i][j] = -1;
				}
			}
			
		}

		public void SetTileSet(TileSet ts)
		{
			tileSet = ts;
			Repaint();
		}

		public void Start()
		{
			thr = new Thread(new ThreadStart(run));
			shouldEnd = false;
            thr.Start();
		}

		public void Stop()
		{
			shouldEnd = true;
		}

		public void run()
		{
			while(!shouldEnd)
			{
				Thread.Sleep(1000);

			}
		}

		private void TileMap_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Repaint();
		}

		public void Repaint()
		{
			if(tileSet == null) return;
			if(backBuff == null) 
				backBuff = new Bitmap(Width, Height);
			
			Graphics buff = Graphics.FromImage(backBuff);
			buff.Clear(Color.Black);
			Graphics g = CreateGraphics();
			
			int xcount = (Width / tileSet.TileSize) + 1;
			int ycount = (Height / tileSet.TileSize) + 1;
			
			int startx = xOffset / tileSet.TileSize;
			int starty = yOffset / tileSet.TileSize;
			
			if(drawMap)
			{
				for(int x = startx; x < startx + xcount; x ++)
				{
					for(int y = starty; y < starty + ycount; y ++)
					{
						if(x < 0 || x >= MapSizeX || y < 0 || y >= MapSizeY) continue;
						if(map[x][y] == -1) continue; // This is an empty square
						buff.DrawImage(tileSet[map[x][y]], x * tileSet.TileSize - xOffset, y * tileSet.TileSize - yOffset);
					}
				}
			}

			if(drawDetail)
			{
				for(int x = startx; x < startx + xcount; x ++)
				{
					for(int y = starty; y < starty + ycount; y ++)
					{
						if(x < 0 || x >= MapSizeX || y < 0 || y >= MapSizeY) continue;
						if(detailmap[x][y] == -1) continue; // This is an empty square
						buff.DrawImage(tileSet[detailmap[x][y]], x * tileSet.TileSize - xOffset, y * tileSet.TileSize - yOffset);
					}
				}
			}

			// Draw Sprites here
			if(drawOverlay)
			{
				for(int x = startx; x < startx + xcount; x ++)
				{
					for(int y = starty; y < starty + ycount; y ++)
					{
						if(x < 0 || x >= MapSizeX || y < 0 || y >= MapSizeY) continue;
						if(overlaymap[x][y] == -1) continue; // This is an empty square
						buff.DrawImage(tileSet[overlaymap[x][y]], x * tileSet.TileSize - xOffset, y * tileSet.TileSize - yOffset);
					}
				}
			}

			g.DrawImage(backBuff, 0, 0);

			
		}

		public Point GetTileCoord(int x, int y)
		{
			Point ret = new Point();
			ret.X = (x + xOffset) / tileSet.TileSize;
			ret.Y = (y + yOffset) / tileSet.TileSize;
			return ret;
		}


		public bool InBounds(int x, int y)
		{
			if(x < 0 || y < 0 || x >= MapSizeX || y >= MapSizeY) return false;
			return true;
		}

		private void TileMap_Resize(object sender, System.EventArgs e)
		{
			if( (Width == 0) || (Height == 0) ) return;
			backBuff = new Bitmap(Width, Height);
		}

		public int XOffset
		{
			get
			{
				return xOffset;
			}
			set
			{
				xOffset = value;
			}
		}

		public int YOffset
		{
			get
			{
				return yOffset;
			}
			set
			{
				yOffset = value;
			}
		}

		public int MapSizeX
		{
			get
			{
				return map.GetLength(0);
			}
		}

		public int MapSizeY
		{
			get
			{
                return map[0].GetLength(0);
			}
		}

		public int[][] this [int index]
		{
			get
			{
				if(index == 0)
					return map;
				if(index == 1)
					return detailmap;
				if(index == 2)
					return overlaymap;
				return null;
			}
		}
		public bool DrawMap
		{
			get
			{
				return drawMap;
			}
			set
			{
				drawMap = value;
			}
		}
		public bool DrawDetail
		{
			get
			{
				return drawDetail;
			}
			set
			{
				drawDetail = value;
			}
		}
		public bool DrawOverlay
		{
			get
			{
				return drawOverlay;
			}
			set
			{
				drawOverlay = value;
			}
		}
	}
}
