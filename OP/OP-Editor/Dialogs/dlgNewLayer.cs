using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace OP_Editor.Dialogs
{
    public partial class dlgNewLayer : Form
    {
        int _mapWidth;
        int _mapHeight;
        float _vertParallaxValue;
        float _horzParallaxValue;
        string _name;
        private NewType _type;

        public enum NewType { Map, Layer, EditMap, EditLayer }

        public int MapWidth { get { return this._mapWidth; } }
        public int MapHeight { get { return this._mapHeight; } }
        public float ParaVert { get { return this._vertParallaxValue; } }
        public float ParaHorz { get { return this._horzParallaxValue; } }
        public string Label { get { return this._name; } }

        public dlgNewLayer(NewType Type)
        {
            InitializeComponent();
            this._type = Type;

            if (_type == NewType.Map) //Anpassen des Dialogs auf MAP - Standard ist LAYER!
            {
                this.Text = "New Map";
                this.label_LayerHeight.Text = "Map Height";
                this.label_LayerWidth.Text = "Map Width";
                this.label_ParallaxHeaderString.Text = "The base parallax scrolling value is:";
                this.groupBox_LayerDimensions.Text = "Map Dimensions";
                this.groupBox_Scrolling.Text = "Base scrolling value";
                this.button_AddLayer.Text = "Generate";
                this.groupBox_LayerInformation.Text = "General map information";
            }
            if (_type == NewType.EditLayer) //Anpassen des Dialogs auf MAP - Standard ist LAYER!
            {
                this.Text = "Edit Layer";                
                this.button_AddLayer.Text = "Save";                
            }
        }       

        private void checkConsistencyWidth(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_MapWidth.Text, out _mapWidth))
            { }
            else
            { 
                if(_type == NewType.Map)
                    MessageBox.Show("The value for the width of the map is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("The value for the width of the layer is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkConsistencyHeight(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_MapHeight.Text, out _mapHeight))
            { }
            else
            {
                if (_type == NewType.Map)
                    MessageBox.Show("The value for the height of the map is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                else
                    MessageBox.Show("The value for the height of the layer is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void checkConsistencyParVert(object sender, EventArgs e)
        {            
            if (float.TryParse(textBox_ParallaxVert.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture, out _vertParallaxValue))
            { }
            else
            {
                if (_type == NewType.Map)
                    MessageBox.Show("The value for the vertical parallax of the map is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                else
                    MessageBox.Show("The value for the vertical parallax of the layer is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void checkConsistencyParHorz(object sender, EventArgs e)
        {
            if (float.TryParse(textBox_ParallaxHorz.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentUICulture, out _horzParallaxValue))
            { }
            else
            {
                if (_type == NewType.Map)
                    MessageBox.Show("The value for the horizontal parallax of the map is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                else
                    MessageBox.Show("The value for the horizontal parallax of the layer is unacceptable!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
        private void parseName(object sender, EventArgs e)
        {
            _name = textBox_Name.Text;
        }  

        private void VerifyAndSet(object sender, FormClosingEventArgs e)
        {
            checkConsistencyHeight(sender, e);
            checkConsistencyWidth(sender, e);
            checkConsistencyParHorz(sender, e);
            checkConsistencyParVert(sender, e);
            parseName(sender, e);
        }

                    
    }
}
