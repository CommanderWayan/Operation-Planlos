namespace OP_Editor.Dialogs
{
    partial class dlgNewLayer
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_LayerDimensions = new System.Windows.Forms.GroupBox();
            this.textBox_MapHeight = new System.Windows.Forms.TextBox();
            this.textBox_MapWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_LayerHeight = new System.Windows.Forms.Label();
            this.label_LayerWidth = new System.Windows.Forms.Label();
            this.groupBox_Scrolling = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ParallaxHorz = new System.Windows.Forms.TextBox();
            this.textBox_ParallaxVert = new System.Windows.Forms.TextBox();
            this.label_ParallaxHeaderString = new System.Windows.Forms.Label();
            this.button_AddLayer = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_LayerInformation = new System.Windows.Forms.GroupBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.groupBox_LayerDimensions.SuspendLayout();
            this.groupBox_Scrolling.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_LayerInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_LayerDimensions
            // 
            this.groupBox_LayerDimensions.Controls.Add(this.textBox_MapHeight);
            this.groupBox_LayerDimensions.Controls.Add(this.textBox_MapWidth);
            this.groupBox_LayerDimensions.Controls.Add(this.label4);
            this.groupBox_LayerDimensions.Controls.Add(this.label3);
            this.groupBox_LayerDimensions.Controls.Add(this.label_LayerHeight);
            this.groupBox_LayerDimensions.Controls.Add(this.label_LayerWidth);
            this.groupBox_LayerDimensions.Location = new System.Drawing.Point(12, 149);
            this.groupBox_LayerDimensions.Name = "groupBox_LayerDimensions";
            this.groupBox_LayerDimensions.Size = new System.Drawing.Size(268, 73);
            this.groupBox_LayerDimensions.TabIndex = 0;
            this.groupBox_LayerDimensions.TabStop = false;
            this.groupBox_LayerDimensions.Text = "Layer Dimensions";
            // 
            // textBox_MapHeight
            // 
            this.textBox_MapHeight.Location = new System.Drawing.Point(89, 45);
            this.textBox_MapHeight.Name = "textBox_MapHeight";
            this.textBox_MapHeight.Size = new System.Drawing.Size(82, 20);
            this.textBox_MapHeight.TabIndex = 6;
            this.textBox_MapHeight.Text = "64";
            this.textBox_MapHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_MapHeight.TextChanged += new System.EventHandler(this.checkConsistencyHeight);
            // 
            // textBox_MapWidth
            // 
            this.textBox_MapWidth.Location = new System.Drawing.Point(89, 19);
            this.textBox_MapWidth.Name = "textBox_MapWidth";
            this.textBox_MapWidth.Size = new System.Drawing.Size(82, 20);
            this.textBox_MapWidth.TabIndex = 1;
            this.textBox_MapWidth.Text = "64";
            this.textBox_MapWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_MapWidth.TextChanged += new System.EventHandler(this.checkConsistencyWidth);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tiles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tiles";
            // 
            // label_LayerHeight
            // 
            this.label_LayerHeight.AutoSize = true;
            this.label_LayerHeight.Location = new System.Drawing.Point(6, 48);
            this.label_LayerHeight.Name = "label_LayerHeight";
            this.label_LayerHeight.Size = new System.Drawing.Size(67, 13);
            this.label_LayerHeight.TabIndex = 3;
            this.label_LayerHeight.Text = "Layer Height";
            // 
            // label_LayerWidth
            // 
            this.label_LayerWidth.AutoSize = true;
            this.label_LayerWidth.Location = new System.Drawing.Point(6, 22);
            this.label_LayerWidth.Name = "label_LayerWidth";
            this.label_LayerWidth.Size = new System.Drawing.Size(64, 13);
            this.label_LayerWidth.TabIndex = 2;
            this.label_LayerWidth.Text = "Layer Width";
            // 
            // groupBox_Scrolling
            // 
            this.groupBox_Scrolling.Controls.Add(this.label7);
            this.groupBox_Scrolling.Controls.Add(this.label6);
            this.groupBox_Scrolling.Controls.Add(this.textBox_ParallaxHorz);
            this.groupBox_Scrolling.Controls.Add(this.textBox_ParallaxVert);
            this.groupBox_Scrolling.Controls.Add(this.label_ParallaxHeaderString);
            this.groupBox_Scrolling.Location = new System.Drawing.Point(12, 228);
            this.groupBox_Scrolling.Name = "groupBox_Scrolling";
            this.groupBox_Scrolling.Size = new System.Drawing.Size(268, 100);
            this.groupBox_Scrolling.TabIndex = 1;
            this.groupBox_Scrolling.TabStop = false;
            this.groupBox_Scrolling.Text = "Scrolling factor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Horizontal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vertical";
            // 
            // textBox_ParallaxHorz
            // 
            this.textBox_ParallaxHorz.Location = new System.Drawing.Point(9, 58);
            this.textBox_ParallaxHorz.Name = "textBox_ParallaxHorz";
            this.textBox_ParallaxHorz.Size = new System.Drawing.Size(82, 20);
            this.textBox_ParallaxHorz.TabIndex = 4;
            this.textBox_ParallaxHorz.Text = "1,0";
            this.textBox_ParallaxHorz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_ParallaxHorz.TextChanged += new System.EventHandler(this.checkConsistencyParHorz);
            // 
            // textBox_ParallaxVert
            // 
            this.textBox_ParallaxVert.Location = new System.Drawing.Point(9, 32);
            this.textBox_ParallaxVert.Name = "textBox_ParallaxVert";
            this.textBox_ParallaxVert.Size = new System.Drawing.Size(82, 20);
            this.textBox_ParallaxVert.TabIndex = 3;
            this.textBox_ParallaxVert.Text = "1,0";
            this.textBox_ParallaxVert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_ParallaxVert.TextChanged += new System.EventHandler(this.checkConsistencyParVert);
            // 
            // label_ParallaxHeaderString
            // 
            this.label_ParallaxHeaderString.AutoSize = true;
            this.label_ParallaxHeaderString.Location = new System.Drawing.Point(6, 16);
            this.label_ParallaxHeaderString.Name = "label_ParallaxHeaderString";
            this.label_ParallaxHeaderString.Size = new System.Drawing.Size(208, 13);
            this.label_ParallaxHeaderString.TabIndex = 2;
            this.label_ParallaxHeaderString.Text = "The parallax scrolling factor (from Base)  is:";
            // 
            // button_AddLayer
            // 
            this.button_AddLayer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_AddLayer.Location = new System.Drawing.Point(7, 3);
            this.button_AddLayer.Name = "button_AddLayer";
            this.button_AddLayer.Size = new System.Drawing.Size(75, 23);
            this.button_AddLayer.TabIndex = 2;
            this.button_AddLayer.Text = "Add";
            this.button_AddLayer.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(186, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button_AddLayer);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(12, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 37);
            this.panel1.TabIndex = 4;
            // 
            // groupBox_LayerInformation
            // 
            this.groupBox_LayerInformation.Controls.Add(this.textBox_Name);
            this.groupBox_LayerInformation.Controls.Add(this.label_Name);
            this.groupBox_LayerInformation.Location = new System.Drawing.Point(12, 12);
            this.groupBox_LayerInformation.Name = "groupBox_LayerInformation";
            this.groupBox_LayerInformation.Size = new System.Drawing.Size(268, 131);
            this.groupBox_LayerInformation.TabIndex = 5;
            this.groupBox_LayerInformation.TabStop = false;
            this.groupBox_LayerInformation.Text = "General layer information";
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(6, 22);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(35, 13);
            this.label_Name.TabIndex = 6;
            this.label_Name.Text = "Name";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(57, 19);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(205, 20);
            this.textBox_Name.TabIndex = 7;
            this.textBox_Name.Text = "NEW";
            this.textBox_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Name.TextChanged += new System.EventHandler(this.parseName);
            // 
            // dlgNewLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 384);
            this.Controls.Add(this.groupBox_LayerInformation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox_Scrolling);
            this.Controls.Add(this.groupBox_LayerDimensions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgNewLayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Layer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerifyAndSet);
            this.groupBox_LayerDimensions.ResumeLayout(false);
            this.groupBox_LayerDimensions.PerformLayout();
            this.groupBox_Scrolling.ResumeLayout(false);
            this.groupBox_Scrolling.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox_LayerInformation.ResumeLayout(false);
            this.groupBox_LayerInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_LayerDimensions;
        private System.Windows.Forms.TextBox textBox_MapHeight;
        private System.Windows.Forms.TextBox textBox_MapWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_LayerHeight;
        private System.Windows.Forms.Label label_LayerWidth;
        private System.Windows.Forms.GroupBox groupBox_Scrolling;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ParallaxHorz;
        private System.Windows.Forms.TextBox textBox_ParallaxVert;
        private System.Windows.Forms.Label label_ParallaxHeaderString;
        private System.Windows.Forms.Button button_AddLayer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox_LayerInformation;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_Name;
    }
}