namespace WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._buttonX = new System.Windows.Forms.Button();
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._toolStripMenuItemA = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemB = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemC = new System.Windows.Forms.ToolStripMenuItem();
            this._grid = new System.Windows.Forms.DataGridView();
            this._colText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colCombo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this._buttonFile = new System.Windows.Forms.Button();
            this._contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonX
            // 
            this._buttonX.Location = new System.Drawing.Point(34, 13);
            this._buttonX.Name = "_buttonX";
            this._buttonX.Size = new System.Drawing.Size(75, 23);
            this._buttonX.TabIndex = 0;
            this._buttonX.Text = "X";
            this._buttonX.UseVisualStyleBackColor = true;
            this._buttonX.Click += new System.EventHandler(this._buttonX_Click);
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItemA,
            this._toolStripMenuItemB,
            this._toolStripMenuItemC});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.Size = new System.Drawing.Size(83, 70);
            // 
            // _toolStripMenuItemA
            // 
            this._toolStripMenuItemA.Name = "_toolStripMenuItemA";
            this._toolStripMenuItemA.Size = new System.Drawing.Size(82, 22);
            this._toolStripMenuItemA.Text = "A";
            this._toolStripMenuItemA.Click += new System.EventHandler(this._toolStripMenuItemA_Click);
            // 
            // _toolStripMenuItemB
            // 
            this._toolStripMenuItemB.Name = "_toolStripMenuItemB";
            this._toolStripMenuItemB.Size = new System.Drawing.Size(82, 22);
            this._toolStripMenuItemB.Text = "B";
            this._toolStripMenuItemB.Click += new System.EventHandler(this._toolStripMenuItemB_Click);
            // 
            // _toolStripMenuItemC
            // 
            this._toolStripMenuItemC.Name = "_toolStripMenuItemC";
            this._toolStripMenuItemC.Size = new System.Drawing.Size(82, 22);
            this._toolStripMenuItemC.Text = "C";
            this._toolStripMenuItemC.Click += new System.EventHandler(this._toolStripMenuItemC_Click);
            // 
            // _grid
            // 
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colText,
            this._colCombo});
            this._grid.Location = new System.Drawing.Point(12, 71);
            this._grid.Name = "_grid";
            this._grid.RowTemplate.Height = 21;
            this._grid.Size = new System.Drawing.Size(262, 150);
            this._grid.TabIndex = 1;
            // 
            // _colText
            // 
            this._colText.HeaderText = "テキスト";
            this._colText.Name = "_colText";
            // 
            // _colCombo
            // 
            this._colCombo.HeaderText = "コンボ";
            this._colCombo.Name = "_colCombo";
            // 
            // _buttonFile
            // 
            this._buttonFile.Location = new System.Drawing.Point(138, 12);
            this._buttonFile.Name = "_buttonFile";
            this._buttonFile.Size = new System.Drawing.Size(75, 23);
            this._buttonFile.TabIndex = 2;
            this._buttonFile.Text = "File";
            this._buttonFile.UseVisualStyleBackColor = true;
            this._buttonFile.Click += new System.EventHandler(this._buttonFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ContextMenuStrip = this._contextMenuStrip;
            this.Controls.Add(this._buttonFile);
            this.Controls.Add(this._grid);
            this.Controls.Add(this._buttonX);
            this.Name = "MainForm";
            this.Text = "Form1";
            this._contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _buttonX;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemA;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemB;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItemC;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colText;
        private System.Windows.Forms.DataGridViewComboBoxColumn _colCombo;
        private System.Windows.Forms.Button _buttonFile;
    }
}

