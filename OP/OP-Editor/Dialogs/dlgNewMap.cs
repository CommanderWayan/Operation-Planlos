using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OP_Editor.Dialogs
{
    public partial class dlgNewMap : Form
    {
        int _mapWidth;
        int _mapHeight;
        float _vertParallaxValue;
        float _horzParallaxValue;

        public dlgNewMap()
        {
            InitializeComponent();
        }
        public int MapWidth { get { return this._mapWidth; } }
        public int MapHeight { get { return this._mapWidth; } }
        public float ParaVert { get { return this._vertParallaxValue; } }
        public float ParaHorz { get { return this._horzParallaxValue; } }
        private void checkConsistencyWidth(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_MapWidth.Text, out _mapWidth))
            { }
            else
            { MessageBox.Show("The value for the width of the map is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void checkConsistencyHeight(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_MapHeight.Text, out _mapHeight))
            { }
            else
            { MessageBox.Show("The value for the height of the map is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void checkConsistencyParVert(object sender, EventArgs e)
        {
            if (float.TryParse(textBox_ParallaxVert.Text, out _vertParallaxValue))
            { }
            else
            { MessageBox.Show("The value for the width of the map is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void checkConsistencyParHorz(object sender, EventArgs e)
        {
            if (float.TryParse(textBox_ParallaxHorz.Text, out _horzParallaxValue))
            { }
            else
            { MessageBox.Show("The value for the width of the map is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        //public int MapWidth { get { return (int)this.textBox_MapWidth.Text; } }
    }
}
