namespace OP_Editor
{
	partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTexturesheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogTextureSheet = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.button_RemoveLayer = new System.Windows.Forms.Button();
            this.listBox_Layers = new System.Windows.Forms.ListBox();
            this.button_AddLayer = new System.Windows.Forms.Button();
            this.button_LayerUp = new System.Windows.Forms.Button();
            this.button_LayerDown = new System.Windows.Forms.Button();
            this.mapViewer = new OP_Editor.Components.MapViewer();
            this.tileBrowser1 = new OP_Editor.Components.TileBrowser();
            this.button_EditLayer = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1457, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.addTexturesheetToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.newMapToolStripMenuItem.Text = "New Map...";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            // 
            // addTexturesheetToolStripMenuItem
            // 
            this.addTexturesheetToolStripMenuItem.Name = "addTexturesheetToolStripMenuItem";
            this.addTexturesheetToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addTexturesheetToolStripMenuItem.Text = "Add Texturesheet";
            this.addTexturesheetToolStripMenuItem.Click += new System.EventHandler(this.addTexturesheetToolStripMenuItem_Click);
            // 
            // openFileDialogTextureSheet
            // 
            this.openFileDialogTextureSheet.Filter = "PNG-Dateien|*.png";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tileBrowser1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 253);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 569);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile Browser";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 846);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1457, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button_EditLayer);
            this.splitContainer1.Panel2.Controls.Add(this.button_LayerDown);
            this.splitContainer1.Panel2.Controls.Add(this.button_LayerUp);
            this.splitContainer1.Panel2.Controls.Add(this.button_RemoveLayer);
            this.splitContainer1.Panel2.Controls.Add(this.listBox_Layers);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1457, 822);
            this.splitContainer1.SplitterDistance = 1052;
            this.splitContainer1.TabIndex = 6;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mapViewer);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1028, 797);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1052, 822);
            this.toolStripContainer1.TabIndex = 10;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 80);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(22, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(22, 20);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(22, 20);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // button_RemoveLayer
            // 
            this.button_RemoveLayer.Location = new System.Drawing.Point(234, 38);
            this.button_RemoveLayer.Name = "button_RemoveLayer";
            this.button_RemoveLayer.Size = new System.Drawing.Size(155, 23);
            this.button_RemoveLayer.TabIndex = 7;
            this.button_RemoveLayer.Text = "Remove Layer";
            this.button_RemoveLayer.UseVisualStyleBackColor = true;
            this.button_RemoveLayer.Click += new System.EventHandler(this.button_RemoveLayer_Click);
            // 
            // listBox_Layers
            // 
            this.listBox_Layers.FormattingEnabled = true;
            this.listBox_Layers.Location = new System.Drawing.Point(6, 9);
            this.listBox_Layers.Name = "listBox_Layers";
            this.listBox_Layers.Size = new System.Drawing.Size(222, 238);
            this.listBox_Layers.TabIndex = 4;
            // 
            // button_AddLayer
            // 
            this.button_AddLayer.Location = new System.Drawing.Point(1290, 33);
            this.button_AddLayer.Name = "button_AddLayer";
            this.button_AddLayer.Size = new System.Drawing.Size(155, 23);
            this.button_AddLayer.TabIndex = 5;
            this.button_AddLayer.Text = "Add Layer";
            this.button_AddLayer.UseVisualStyleBackColor = true;
            this.button_AddLayer.Click += new System.EventHandler(this.button_AddLayer_Click);
            // 
            // button_LayerUp
            // 
            this.button_LayerUp.Location = new System.Drawing.Point(234, 224);
            this.button_LayerUp.Name = "button_LayerUp";
            this.button_LayerUp.Size = new System.Drawing.Size(75, 23);
            this.button_LayerUp.TabIndex = 8;
            this.button_LayerUp.Text = "Up";
            this.button_LayerUp.UseVisualStyleBackColor = true;
            this.button_LayerUp.Click += new System.EventHandler(this.button_LayerUp_Click);
            // 
            // button_LayerDown
            // 
            this.button_LayerDown.Location = new System.Drawing.Point(234, 195);
            this.button_LayerDown.Name = "button_LayerDown";
            this.button_LayerDown.Size = new System.Drawing.Size(75, 23);
            this.button_LayerDown.TabIndex = 9;
            this.button_LayerDown.Text = "Down";
            this.button_LayerDown.UseVisualStyleBackColor = true;
            this.button_LayerDown.Click += new System.EventHandler(this.button_LayerDown_Click);
            // 
            // mapViewer
            // 
            this.mapViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mapViewer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mapViewer.Location = new System.Drawing.Point(7, 3);
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.Size = new System.Drawing.Size(1018, 788);
            this.mapViewer.TabIndex = 5;
            // 
            // tileBrowser1
            // 
            this.tileBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tileBrowser1.Location = new System.Drawing.Point(6, 19);
            this.tileBrowser1.Name = "tileBrowser1";
            this.tileBrowser1.Size = new System.Drawing.Size(389, 544);
            this.tileBrowser1.TabIndex = 0;
            // 
            // button_EditLayer
            // 
            this.button_EditLayer.Location = new System.Drawing.Point(234, 67);
            this.button_EditLayer.Name = "button_EditLayer";
            this.button_EditLayer.Size = new System.Drawing.Size(155, 23);
            this.button_EditLayer.TabIndex = 10;
            this.button_EditLayer.Text = "Edit Layer";
            this.button_EditLayer.UseVisualStyleBackColor = true;
            this.button_EditLayer.Click += new System.EventHandler(this.button_EditLayer_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 868);
            this.Controls.Add(this.button_AddLayer);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addTexturesheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogTextureSheet;
        private System.Windows.Forms.GroupBox groupBox1;
		private Components.TileBrowser tileBrowser1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private Components.MapViewer mapViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ListBox listBox_Layers;
        private System.Windows.Forms.Button button_AddLayer;
        private System.Windows.Forms.Button button_RemoveLayer;
        private System.Windows.Forms.Button button_LayerDown;
        private System.Windows.Forms.Button button_LayerUp;
        private System.Windows.Forms.Button button_EditLayer;
	}
}

