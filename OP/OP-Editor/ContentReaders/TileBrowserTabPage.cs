using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using OP_Editor.Textures;

namespace OP_Editor.ContentReaders
{
    class TileBrowserTabPage : TabPage
    {
        private ScrollBar hScrollBar;
        private ScrollBar vScrollBar;

        private TextureSheet _textureSheet;

        Point _selectedTile;
        bool[,] _multiSelectedTiles;
        bool _multiselected;

        private int scrollBarWidth = 17;

        public TileBrowserTabPage()
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
            this.vScrollBar.Location = new System.Drawing.Point(0, scrollBarWidth);
            this.vScrollBar.Name = "vScrollBar";
            //this.vScrollBar.Size = new System.Drawing.Size(scrollBarWidth, 410);
            this.vScrollBar.Size = new System.Drawing.Size(scrollBarWidth, this.Height - scrollBarWidth);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.ValueChanged += new System.EventHandler(this.scrollBar_ValueChanged);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Enabled = false;
            this.hScrollBar.Location = new System.Drawing.Point(scrollBarWidth, 0);
            this.hScrollBar.Name = "hScrollBar";
            //this.hScrollBar.Size = new System.Drawing.Size(460, scrollBarWidth); //woher die 460?
            this.hScrollBar.Size = new System.Drawing.Size(this.Width - scrollBarWidth, scrollBarWidth);
            this.hScrollBar.TabIndex = 1;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.scrollBar_ValueChanged);
            // 
            // TileBrowserTabPage
            //
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Name = "TileBrowser";
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            //this.Load += new System.EventHandler(this.TileBrowser_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TileBrowserTabPage_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileBrowser_MouseDown);
            this.Resize += new System.EventHandler(this.TileBrowserTabPage_Resize);
            this.ResumeLayout(false);
        }

        private bool checkIfMultipleSelectionIsConnected()
        {
            //Überprüfen ob die auswahl zusammenhängend ist (muß sie für "pinsel" - muss sie nicht für "füllen")
            //NICHT VERBUNDEN IST - es gibt mindestens 2 TRUE Gruppen, welche nicht verbunden sind.....
            //IDEE: array kopieren - true suchen - rekursiv auf false setzen - true suchen - wenn gefunden - dann nicht verbunden.... ist das effektiv?

            bool connected = false;
            bool[,] selectionmapCopy = new bool[_multiSelectedTiles.GetLength(0), _multiSelectedTiles.GetLength(1)];

            Array.Copy(_multiSelectedTiles, selectionmapCopy, _multiSelectedTiles.Length);
            int blobsfound = 0;
            for (int x = 0; x < selectionmapCopy.GetLength(0); x++)
            {
                for (int y = 0; y < selectionmapCopy.GetLength(1); y++)
                {
                    if (selectionmapCopy[x, y])
                    {
                        checkAndMarkNeighbors(ref selectionmapCopy, x, y);
                        blobsfound++;
                    }


                }
            }
            if (blobsfound > 1)
                connected = false;
            else
                connected = true;

            return connected;
        }

        private void checkAndMarkNeighbors(ref bool[,] selectionmapCopy, int x, int y)
        {
            //überprüfen aller 8 nachbarn und false setzen.
            /*
             * x-1,y-1    x,y-1   x+1,y-1
             * x-1,y              x+1,y
             * x-1,y+1    x,y+1   x+1,y+1
             * */

            selectionmapCopy[x, y] = false;
            Console.WriteLine(selectionmapCopy.GetLength(0).ToString() + " " + selectionmapCopy.GetLength(1));
            Console.WriteLine(selectionmapCopy.GetUpperBound(0) + " " + selectionmapCopy.GetUpperBound(1));

            if ((x > 0 & y > 0) && selectionmapCopy[x - 1, y - 1])
                checkAndMarkNeighbors(ref selectionmapCopy, x - 1, y - 1);
            if ((y > 0) && selectionmapCopy[x, y - 1])
                checkAndMarkNeighbors(ref selectionmapCopy, x, y - 1);
            if ((y > 0 & x < selectionmapCopy.GetUpperBound(0)) && selectionmapCopy[x + 1, y - 1])
                checkAndMarkNeighbors(ref selectionmapCopy, x + 1, y - 1);
            if ((x > 0) && selectionmapCopy[x - 1, y])
                checkAndMarkNeighbors(ref selectionmapCopy, x - 1, y);
            if ((x < selectionmapCopy.GetUpperBound(0)) && selectionmapCopy[x + 1, y])
                checkAndMarkNeighbors(ref selectionmapCopy, x + 1, y);
            if ((x > 0 & y < selectionmapCopy.GetUpperBound(1)) && selectionmapCopy[x - 1, y + 1])
                checkAndMarkNeighbors(ref selectionmapCopy, x - 1, y + 1);
            if ((y < selectionmapCopy.GetUpperBound(1)) && selectionmapCopy[x, y + 1])
                checkAndMarkNeighbors(ref selectionmapCopy, x, y + 1);
            if ((x < selectionmapCopy.GetUpperBound(0) & y < selectionmapCopy.GetUpperBound(1)) && selectionmapCopy[x + 1, y + 1])
                checkAndMarkNeighbors(ref selectionmapCopy, x + 1, y + 1);
        }

        private void TileBrowser_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Tile Auswählen
            //übertragen in selectedtile
            // löscht den rahmen - aber flackert manchmal :(
            if (_textureSheet == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if ((e.X > _textureSheet.XTiles * _textureSheet.TileWidth + vScrollBar.Width - 1) | (e.Y > _textureSheet.YTiles * _textureSheet.TileHeight + hScrollBar.Height - 1))
                    return;

                if (Control.ModifierKeys == Keys.Control)
                {
                    //MULTISELECT                    
                    _multiselected = true;
                    _selectedTile = new Point(-1, -1);
                    Point selection = new Point((e.X - vScrollBar.Width) / _textureSheet.TileWidth + hScrollBar.Value, (e.Y - hScrollBar.Height) / _textureSheet.TileHeight + vScrollBar.Value);
                    _multiSelectedTiles[selection.X, selection.Y] = !_multiSelectedTiles[selection.X, selection.Y];
                    Console.WriteLine("LMB & CTRL" + _multiSelectedTiles.ToString());

                }
                else
                {
                    //Single Select
                    _multiselected = false;
                    _multiSelectedTiles = new bool[_textureSheet.XTiles, _textureSheet.YTiles];
                    _selectedTile.X = (e.X - vScrollBar.Width) / _textureSheet.TileWidth + hScrollBar.Value;
                    _selectedTile.Y = (e.Y - hScrollBar.Height) / _textureSheet.TileHeight + vScrollBar.Value;
                    Console.WriteLine("SELECT: " + _selectedTile.ToString());
                }

            }
            if (e.Button == MouseButtons.Right)
            {
                //DESELECT
                _selectedTile = new Point(-1, -1);
                _multiSelectedTiles = new bool[_textureSheet.XTiles, _textureSheet.YTiles];
                Console.WriteLine("DESELECT: " + _selectedTile.ToString());
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                bool x = checkIfMultipleSelectionIsConnected();
                Console.WriteLine(x.ToString());
            }

            PaintAll();
        }

        private void TileBrowserTabPage_Resize(object sender, System.EventArgs e)
        {
            vScrollBar.Height = Height - 16;
            hScrollBar.Width = Width - 16;
        }

        private void PaintAll()
        {
            //Scrollbars überprüfen!
            //Teile in Graphics zeichnen!
            //Selektiertes teil hervorheben!
            //MULTISELSECT?
            if (_textureSheet == null)
                return;


            Graphics gfx = CreateGraphics();
            Bitmap tempBmp = new Bitmap(_textureSheet.TileWidth * _textureSheet.XTiles, _textureSheet.TileHeight * _textureSheet.YTiles);
            Graphics tempGfx = Graphics.FromImage(tempBmp);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            tempGfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            tempGfx.Clear(this.BackColor);


            for (int x = 0; x < _textureSheet.XTiles; x++)
            {
                for (int y = 0; y < _textureSheet.YTiles; y++)
                {

                    Rectangle cutRec = new Rectangle(x * _textureSheet.TileWidth - hScrollBar.Value * _textureSheet.TileWidth,
                                                                    y * _textureSheet.TileHeight - vScrollBar.Value * _textureSheet.TileHeight,
                                                                    _textureSheet.TileWidth,
                                                                    _textureSheet.TileHeight);

                    tempGfx.DrawImageUnscaledAndClipped(_textureSheet[x, y], cutRec);

                    Rectangle drawRec = new Rectangle(x * _textureSheet.TileWidth - hScrollBar.Value * _textureSheet.TileWidth,
                                                                    y * _textureSheet.TileHeight - vScrollBar.Value * _textureSheet.TileHeight,
                                                                    _textureSheet.TileWidth - 1,
                                                                    _textureSheet.TileHeight - 1);
                    if (!_multiselected && _selectedTile == new Point(x, y))
                    {
                        tempGfx.DrawRectangle(new Pen(Color.Red), drawRec);
                    }
                    if (_multiselected && _multiSelectedTiles[x, y])
                    {
                        tempGfx.DrawRectangle(new Pen(Color.Red), drawRec);
                    }
                }
            }

            gfx.DrawImage(tempBmp, 0 + vScrollBar.Width, 0 + hScrollBar.Height);
        }

        private void scrollBar_ValueChanged(object sender, System.EventArgs e)
        {
            PaintAll();
        }

        private void TileBrowserTabPage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            PaintAll();
        }
    }
}
