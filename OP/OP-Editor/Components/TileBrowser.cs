using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using OP_Editor.Textures;
using OP_Editor.ContentReaders;


namespace OP_Editor.Components
{
    public class TileBrowser : System.Windows.Forms.UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        //private System.Windows.Forms.VScrollBar vScrollBar;
        //private System.Windows.Forms.HScrollBar hScrollBar;
        //private TileBrowserTabPage testTab;
        private System.Windows.Forms.TabControl testTabCon;
        int _browserWidth;
        int _browserHeight;

        //private TextureSheet _textureSheet;

        //Point _selectedTile;
        //bool[,] _multiSelectedTiles;
        //bool _multiselected;

        //private const int browserWidth = 505;
        //private const int browserHeight = 475; //warum vorher 459?
        private const int scrollBarWidth = 17;

        public TileBrowser()
        {
            InitializeComponent();
            #region double buffering
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            #endregion
        }
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();                    
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            //this.vScrollBar = new System.Windows.Forms.VScrollBar();
            //this.hScrollBar = new System.Windows.Forms.HScrollBar();
            //this.testTab = new TileBrowserTabPage();
            this.testTabCon = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            //this.vScrollBar.Enabled = false;
            //this.vScrollBar.Location = new System.Drawing.Point(0, scrollBarWidth);
            //this.vScrollBar.Name = "vScrollBar";
            ////this.vScrollBar.Size = new System.Drawing.Size(scrollBarWidth, 410);
            //this.vScrollBar.Size = new System.Drawing.Size(scrollBarWidth,this.Height - scrollBarWidth);
            //this.vScrollBar.TabIndex = 0;
            //this.vScrollBar.ValueChanged += new System.EventHandler(this.scrollBar_ValueChanged);
            //// 
            //// hScrollBar
            //// 
            //this.hScrollBar.Enabled = false;
            //this.hScrollBar.Location = new System.Drawing.Point(scrollBarWidth, 0);
            //this.hScrollBar.Name = "hScrollBar";
            ////this.hScrollBar.Size = new System.Drawing.Size(460, scrollBarWidth); //woher die 460?
            //this.hScrollBar.Size = new System.Drawing.Size(this.Width - scrollBarWidth, scrollBarWidth);
            //this.hScrollBar.TabIndex = 1;
            //this.hScrollBar.ValueChanged += new System.EventHandler(this.scrollBar_ValueChanged);
            //
            //TabPage
            //
            //this.testTab.Location = new System.Drawing.Point(vScrollBar.Width, hScrollBar.Height);
            //this.testTab.Name = "tabPage1";
            //this.testTab.Padding = new System.Windows.Forms.Padding(3);
            //this.testTab.Size = new System.Drawing.Size(this.Width, this.Height);
            //this.testTab.TabIndex = 0;
            //this.testTab.Text = "tabPage1";
            //this.testTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            //this.testTabCon.Controls.Add(this.testTab);
            //this.testTabCon.Controls.Add(this.testTab);
            this.testTabCon.Location = new System.Drawing.Point(0, 0);
            this.testTabCon.Name = "tabControl1";
            this.testTabCon.SelectedIndex = 0;
            this.testTabCon.Size = new System.Drawing.Size(this.Width, this.Height);
            this.testTabCon.TabIndex = 4;
            // 
            // TileBrowser
            // 
            //this.Controls.Add(this.vScrollBar);
            //this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.testTabCon);
            this.Name = "TileBrowser";
            this.Size = new System.Drawing.Size(this.Width, this.Height);
            this.Load += new System.EventHandler(this.TileBrowser_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TileBrowser_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TileBrowser_MouseDown);
            this.Resize += new System.EventHandler(this.TileBrowser_Resize);
            this.ResumeLayout(false);

        }
        public void setTextureSheet(TextureSheet Ts, String Name)
        {
            
            TileBrowserTabPage test = new TileBrowserTabPage();
            test.Location = new System.Drawing.Point(0, 0);
            test.Name = Name;
            test.Padding = new System.Windows.Forms.Padding(3);
            test.Size = new System.Drawing.Size(this.Width, this.Height);
            test.TabIndex = 0;
            test.Text = Name;
            test.UseVisualStyleBackColor = true;

            test.setTextureSheet(Ts);

            this.testTabCon.Controls.Add(test);
            this.testTabCon.SelectedTab = test;

            //Invalidate();
            //_textureSheet = Ts;

            //_selectedTile = new Point(-1, -1);
            //_multiSelectedTiles = new bool[_textureSheet.XTiles, _textureSheet.YTiles];

            //if (_textureSheet == null)
            //{
            //    vScrollBar.Enabled = false;
            //    hScrollBar.Enabled = false;
            //    Update();
            //    return;
            //}
            ////Schauen wir mal wieviele teile wir grad darstellen können
            //int columns = _browserWidth / _textureSheet.TileWidth;
            //int rows = _browserHeight / _textureSheet.TileHeight;
            ////gucken ob das ohne Scrollbars reicht
            //if (columns < _textureSheet.XTiles) //reicht nicht von der Breite
            //{
            //    hScrollBar.Enabled = true;
            //    hScrollBar.Minimum = 0;
            //    hScrollBar.Maximum = _textureSheet.XTiles - columns / 2; //check if wirklich so /2
            //    hScrollBar.Value = 0;
            //}
            //else
            //{
            //    hScrollBar.Enabled = false;
            //    hScrollBar.Value = 0;
            //}
            //if (rows < _textureSheet.YTiles) //reicht nicht von der Höhe
            //{
            //    vScrollBar.Enabled = true;
            //    vScrollBar.Minimum = 0;
            //    vScrollBar.Maximum = _textureSheet.YTiles - rows / 2; //check if wirklich so /2
            //    vScrollBar.Value = 0;
            //}
            //else
            //{
            //    vScrollBar.Enabled = false;
            //    vScrollBar.Value = 0;
            //}
            //PaintAll();
            //Update();
        }
        //private bool checkIfMultipleSelectionIsConnected()
        //{
        //    //Überprüfen ob die auswahl zusammenhängend ist (muß sie für "pinsel" - muss sie nicht für "füllen")
        //    //NICHT VERBUNDEN IST - es gibt mindestens 2 TRUE Gruppen, welche nicht verbunden sind.....
        //    //IDEE: array kopieren - true suchen - rekursiv auf false setzen - true suchen - wenn gefunden - dann nicht verbunden.... ist das effektiv?

        //    bool connected = false;
        //    bool[,] selectionmapCopy = new bool[_multiSelectedTiles.GetLength(0),_multiSelectedTiles.GetLength(1)];

        //    Array.Copy(_multiSelectedTiles, selectionmapCopy, _multiSelectedTiles.Length);
        //    int blobsfound = 0;
        //    for (int x = 0; x < selectionmapCopy.GetLength(0); x++)
        //    {
        //        for (int y = 0; y < selectionmapCopy.GetLength(1); y++)
        //        {
        //            if (selectionmapCopy[x, y])
        //            {
        //                checkAndMarkNeighbors(ref selectionmapCopy, x, y);
        //                blobsfound++;
        //            }
                    
                    
        //        }
        //    }
        //    if (blobsfound > 1)
        //        connected = false;
        //    else
        //        connected = true;

        //    return connected;            
        //}
        //private void checkAndMarkNeighbors(ref bool[,] selectionmapCopy, int x, int y)
        //{
        //    //überprüfen aller 8 nachbarn und false setzen.
        //    /*
        //     * x-1,y-1    x,y-1   x+1,y-1
        //     * x-1,y              x+1,y
        //     * x-1,y+1    x,y+1   x+1,y+1
        //     * */

        //    selectionmapCopy[x, y] = false;
        //    Console.WriteLine(selectionmapCopy.GetLength(0).ToString() + " " + selectionmapCopy.GetLength(1));
        //    Console.WriteLine(selectionmapCopy.GetUpperBound(0) + " " + selectionmapCopy.GetUpperBound(1));

        //    if ((x > 0 & y > 0) && selectionmapCopy[x-1, y-1])
        //        checkAndMarkNeighbors(ref selectionmapCopy, x-1, y-1);
        //    if ((y > 0) && selectionmapCopy[x, y-1])
        //        checkAndMarkNeighbors(ref selectionmapCopy, x, y-1);
        //    if ((y > 0 & x < selectionmapCopy.GetUpperBound(0)) && selectionmapCopy[x+1, y-1])
        //        checkAndMarkNeighbors(ref selectionmapCopy, x+1, y-1);
        //    if ((x > 0) && selectionmapCopy[x-1, y])
        //        checkAndMarkNeighbors(ref selectionmapCopy, x-1, y);
        //    if ((x < selectionmapCopy.GetUpperBound(0)) && selectionmapCopy[x+1, y])
        //        checkAndMarkNeighbors(ref selectionmapCopy, x+1, y);
        //    if ((x > 0 & y < selectionmapCopy.GetUpperBound(1)) && selectionmapCopy[x-1, y+1])
        //        checkAndMarkNeighbors(ref selectionmapCopy, x-1, y+1);
        //    if ((y < selectionmapCopy.GetUpperBound(1)) && selectionmapCopy[x, y+1])
        //        checkAndMarkNeighbors(ref selectionmapCopy, x, y+1);
        //    if ((x < selectionmapCopy.GetUpperBound(0) & y < selectionmapCopy.GetUpperBound(1)) && selectionmapCopy[x+1, y+1])
        //        checkAndMarkNeighbors(ref selectionmapCopy, x+1, y+1);
        //}
        //EVENTS
        private void TileBrowser_Load(object sender, System.EventArgs e)
        {

        }
        private void TileBrowser_Resize(object sender, System.EventArgs e)
        {
            //vScrollBar.Height = Height - 16;
            //hScrollBar.Width = Width - 16;
            //_browserHeight = Height - hScrollBar.Height;
            //_browserWidth = Width - vScrollBar.Width;
            _browserHeight = Height;
            _browserWidth = Width;
            testTabCon.Height = Height;
            testTabCon.Width = Width;
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
            //if (_textureSheet == null)
            //    return;


            //Graphics gfx = CreateGraphics();
            //Bitmap tempBmp = new Bitmap(_textureSheet.TileWidth * _textureSheet.XTiles, _textureSheet.TileHeight * _textureSheet.YTiles);
            //Graphics tempGfx = Graphics.FromImage(tempBmp);
            //gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            //tempGfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            //tempGfx.Clear(this.BackColor);


            //for (int x = 0; x < _textureSheet.XTiles; x++)
            //{
            //    for (int y = 0; y < _textureSheet.YTiles; y++)
            //    {

            //        Rectangle cutRec = new Rectangle(x * _textureSheet.TileWidth - hScrollBar.Value * _textureSheet.TileWidth,
            //                                                        y * _textureSheet.TileHeight - vScrollBar.Value * _textureSheet.TileHeight,
            //                                                        _textureSheet.TileWidth,
            //                                                        _textureSheet.TileHeight);

            //        tempGfx.DrawImageUnscaledAndClipped(_textureSheet[x, y], cutRec);

            //        Rectangle drawRec = new Rectangle(x * _textureSheet.TileWidth - hScrollBar.Value * _textureSheet.TileWidth,
            //                                                        y * _textureSheet.TileHeight - vScrollBar.Value * _textureSheet.TileHeight,
            //                                                        _textureSheet.TileWidth - 1,
            //                                                        _textureSheet.TileHeight - 1);
            //        if (!_multiselected && _selectedTile == new Point(x, y))
            //        {
            //            tempGfx.DrawRectangle(new Pen(Color.Red), drawRec);
            //        }
            //        if (_multiselected && _multiSelectedTiles[x, y])
            //        {
            //            tempGfx.DrawRectangle(new Pen(Color.Red), drawRec);
            //        }
            //    }
            //}

            //gfx.DrawImage(tempBmp, 0 + vScrollBar.Width, 0 + hScrollBar.Height);
        }
        private void TileBrowser_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Tile Auswählen
            //übertragen in selectedtile
            // löscht den rahmen - aber flackert manchmal :(
            //if (_textureSheet == null)
            //    return;

            //if (e.Button == MouseButtons.Left)
            //{
            //    if ((e.X > _textureSheet.XTiles * _textureSheet.TileWidth + vScrollBar.Width - 1) | (e.Y > _textureSheet.YTiles * _textureSheet.TileHeight + hScrollBar.Height - 1))
            //        return;

            //    if (Control.ModifierKeys == Keys.Control)
            //    {
            //        //MULTISELECT                    
            //        _multiselected = true;
            //        _selectedTile = new Point(-1, -1);
            //        Point selection = new Point((e.X - vScrollBar.Width) / _textureSheet.TileWidth + hScrollBar.Value, (e.Y - hScrollBar.Height) / _textureSheet.TileHeight + vScrollBar.Value);
            //        _multiSelectedTiles[selection.X, selection.Y] = !_multiSelectedTiles[selection.X, selection.Y];
            //        Console.WriteLine("LMB & CTRL" + _multiSelectedTiles.ToString());

            //    }
            //    else
            //    {
            //        //Single Select
            //        _multiselected = false;
            //        _multiSelectedTiles = new bool[_textureSheet.XTiles, _textureSheet.YTiles];
            //        _selectedTile.X = (e.X - vScrollBar.Width) / _textureSheet.TileWidth + hScrollBar.Value;
            //        _selectedTile.Y = (e.Y - hScrollBar.Height) / _textureSheet.TileHeight + vScrollBar.Value;
            //        Console.WriteLine("SELECT: " + _selectedTile.ToString());
            //    }

            //}
            //if (e.Button == MouseButtons.Right)
            //{
            //    //DESELECT
            //    _selectedTile = new Point(-1, -1);
            //    _multiSelectedTiles = new bool[_textureSheet.XTiles, _textureSheet.YTiles];
            //    Console.WriteLine("DESELECT: " + _selectedTile.ToString());
            //}
            //if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            //{
            //    bool x = checkIfMultipleSelectionIsConnected();
            //    Console.WriteLine(x.ToString());
            //}
            
            //PaintAll();
        }
        private void scrollBar_ValueChanged(object sender, System.EventArgs e)
        {
            PaintAll();
        }
    }
}

