namespace SakurasouTranslateTool
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonExtract = new System.Windows.Forms.Button();
            this.dataGridViewStrings = new System.Windows.Forms.DataGridView();
            this.contextMenuStripStrings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPatch = new System.Windows.Forms.Button();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStrings)).BeginInit();
            this.contextMenuStripStrings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExtract
            // 
            this.buttonExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExtract.Location = new System.Drawing.Point(7, 494);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(96, 36);
            this.buttonExtract.TabIndex = 0;
            this.buttonExtract.Text = "Extract";
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // dataGridViewStrings
            // 
            this.dataGridViewStrings.AllowUserToAddRows = false;
            this.dataGridViewStrings.AllowUserToDeleteRows = false;
            this.dataGridViewStrings.AllowUserToResizeRows = false;
            this.dataGridViewStrings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStrings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStrings.ContextMenuStrip = this.contextMenuStripStrings;
            this.dataGridViewStrings.Location = new System.Drawing.Point(1, 0);
            this.dataGridViewStrings.Name = "dataGridViewStrings";
            this.dataGridViewStrings.RowHeadersVisible = false;
            this.dataGridViewStrings.Size = new System.Drawing.Size(557, 488);
            this.dataGridViewStrings.TabIndex = 1;
            // 
            // contextMenuStripStrings
            // 
            this.contextMenuStripStrings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemExport,
            this.itemImport});
            this.contextMenuStripStrings.Name = "contextMenuStripStrings";
            this.contextMenuStripStrings.Size = new System.Drawing.Size(158, 48);
            // 
            // itemExport
            // 
            this.itemExport.Name = "itemExport";
            this.itemExport.Size = new System.Drawing.Size(157, 22);
            this.itemExport.Text = "Export strings...";
            this.itemExport.Click += new System.EventHandler(this.itemExport_Click);
            // 
            // itemImport
            // 
            this.itemImport.Name = "itemImport";
            this.itemImport.Size = new System.Drawing.Size(157, 22);
            this.itemImport.Text = "Import strings...";
            this.itemImport.Click += new System.EventHandler(this.itemImport_Click);
            // 
            // buttonPatch
            // 
            this.buttonPatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPatch.Enabled = false;
            this.buttonPatch.Location = new System.Drawing.Point(106, 494);
            this.buttonPatch.Name = "buttonPatch";
            this.buttonPatch.Size = new System.Drawing.Size(96, 36);
            this.buttonPatch.TabIndex = 2;
            this.buttonPatch.Text = "Patch";
            this.buttonPatch.UseVisualStyleBackColor = true;
            this.buttonPatch.Click += new System.EventHandler(this.buttonPatch_Click);
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurrentFile.Location = new System.Drawing.Point(215, 497);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelCurrentFile.Size = new System.Drawing.Size(332, 30);
            this.labelCurrentFile.TabIndex = 4;
            this.labelCurrentFile.Text = "None";
            this.labelCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 536);
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.buttonPatch);
            this.Controls.Add(this.dataGridViewStrings);
            this.Controls.Add(this.buttonExtract);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STT";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStrings)).EndInit();
            this.contextMenuStripStrings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.DataGridView dataGridViewStrings;
        private System.Windows.Forms.Button buttonPatch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStrings;
        private System.Windows.Forms.ToolStripMenuItem itemExport;
        private System.Windows.Forms.ToolStripMenuItem itemImport;
        private System.Windows.Forms.Label labelCurrentFile;
    }
}

