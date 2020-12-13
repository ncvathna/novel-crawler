namespace NovelCrawler
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblSupport = new System.Windows.Forms.Label();
            this.dgvChapters = new System.Windows.Forms.DataGridView();
            this.btnParse = new System.Windows.Forms.Button();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numConnections = new System.Windows.Forms.NumericUpDown();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtChapter = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConnections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Link to Main Page:";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(114, 6);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(284, 20);
            this.txtLink.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(404, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // lblSupport
            // 
            this.lblSupport.Location = new System.Drawing.Point(12, 36);
            this.lblSupport.Name = "lblSupport";
            this.lblSupport.Size = new System.Drawing.Size(467, 44);
            this.lblSupport.TabIndex = 3;
            this.lblSupport.Text = "Supported Websites: MTLNovel, WordExcerpt, NovelFull, WuxiaWorld, VolareNovels, C" +
    "reativeNovels";
            // 
            // dgvChapters
            // 
            this.dgvChapters.AllowUserToAddRows = false;
            this.dgvChapters.AllowUserToDeleteRows = false;
            this.dgvChapters.AllowUserToResizeRows = false;
            this.dgvChapters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChapters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChapters.Location = new System.Drawing.Point(12, 83);
            this.dgvChapters.Name = "dgvChapters";
            this.dgvChapters.ReadOnly = true;
            this.dgvChapters.RowHeadersVisible = false;
            this.dgvChapters.Size = new System.Drawing.Size(467, 347);
            this.dgvChapters.TabIndex = 4;
            // 
            // btnParse
            // 
            this.btnParse.Enabled = false;
            this.btnParse.Location = new System.Drawing.Point(323, 436);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 5;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            // 
            // pbCover
            // 
            this.pbCover.Location = new System.Drawing.Point(485, 83);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(232, 228);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCover.TabIndex = 6;
            this.pbCover.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(486, 318);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 112);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(12, 436);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(93, 436);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(174, 436);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh Chapters";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(404, 436);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 11;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 469);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Concurrent Connections:";
            // 
            // numConnections
            // 
            this.numConnections.Enabled = false;
            this.numConnections.Location = new System.Drawing.Point(323, 467);
            this.numConnections.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numConnections.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numConnections.Name = "numConnections";
            this.numConnections.Size = new System.Drawing.Size(156, 20);
            this.numConnections.TabIndex = 14;
            this.numConnections.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numDelay
            // 
            this.numDelay.Enabled = false;
            this.numDelay.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numDelay.Location = new System.Drawing.Point(323, 493);
            this.numDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(156, 20);
            this.numDelay.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 495);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Delay (ms):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtChapter);
            this.groupBox1.Location = new System.Drawing.Point(12, 519);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 190);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content";
            // 
            // txtChapter
            // 
            this.txtChapter.Location = new System.Drawing.Point(6, 19);
            this.txtChapter.Name = "txtChapter";
            this.txtChapter.ReadOnly = true;
            this.txtChapter.Size = new System.Drawing.Size(693, 171);
            this.txtChapter.TabIndex = 18;
            this.txtChapter.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 721);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numDelay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numConnections);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.dgvChapters);
            this.Controls.Add(this.lblSupport);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Novel Crawler";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConnections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblSupport;
        private System.Windows.Forms.DataGridView dgvChapters;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numConnections;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtChapter;
    }
}

