namespace wrapdoc
{
    partial class frmScope
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScope));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.updYScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.updXScale = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.treeViewDataSource = new System.Windows.Forms.TreeView();
            this.btnPlotEnabled = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.updSamplingFrequency = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAutoScaleY = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.updYScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updXScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updSamplingFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsShowPointValues = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(137, 9);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.Size = new System.Drawing.Size(712, 488);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // updYScale
            // 
            this.updYScale.Enabled = false;
            this.updYScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.updYScale.Location = new System.Drawing.Point(3, 41);
            this.updYScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updYScale.Name = "updYScale";
            this.updYScale.Size = new System.Drawing.Size(65, 20);
            this.updYScale.TabIndex = 1;
            this.updYScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.updYScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updYScale.ValueChanged += new System.EventHandler(this.updYScale_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "X/div";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "ms/div";
            // 
            // updXScale
            // 
            this.updXScale.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updXScale.Location = new System.Drawing.Point(3, 99);
            this.updXScale.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.updXScale.Name = "updXScale";
            this.updXScale.Size = new System.Drawing.Size(65, 20);
            this.updXScale.TabIndex = 3;
            this.updXScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.updXScale.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.updXScale.ValueChanged += new System.EventHandler(this.updXScale_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Scale:";
            // 
            // treeViewDataSource
            // 
            this.treeViewDataSource.Location = new System.Drawing.Point(3, 228);
            this.treeViewDataSource.Name = "treeViewDataSource";
            this.treeViewDataSource.Size = new System.Drawing.Size(121, 269);
            this.treeViewDataSource.TabIndex = 7;
            // 
            // btnPlotEnabled
            // 
            this.btnPlotEnabled.Location = new System.Drawing.Point(3, 199);
            this.btnPlotEnabled.Name = "btnPlotEnabled";
            this.btnPlotEnabled.Size = new System.Drawing.Size(121, 23);
            this.btnPlotEnabled.TabIndex = 8;
            this.btnPlotEnabled.Text = "Disable Plotting";
            this.btnPlotEnabled.UseVisualStyleBackColor = true;
            this.btnPlotEnabled.Click += new System.EventHandler(this.btnPlotEnabled_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sampling:";
            // 
            // updSamplingFrequency
            // 
            this.updSamplingFrequency.Location = new System.Drawing.Point(3, 159);
            this.updSamplingFrequency.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.updSamplingFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updSamplingFrequency.Name = "updSamplingFrequency";
            this.updSamplingFrequency.Size = new System.Drawing.Size(65, 20);
            this.updSamplingFrequency.TabIndex = 10;
            this.updSamplingFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.updSamplingFrequency.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.updSamplingFrequency.ValueChanged += new System.EventHandler(this.updSamplingFrequency_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hz";
            // 
            // chkAutoScaleY
            // 
            this.chkAutoScaleY.AutoSize = true;
            this.chkAutoScaleY.Checked = true;
            this.chkAutoScaleY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScaleY.Location = new System.Drawing.Point(3, 67);
            this.chkAutoScaleY.Name = "chkAutoScaleY";
            this.chkAutoScaleY.Size = new System.Drawing.Size(130, 17);
            this.chkAutoScaleY.TabIndex = 12;
            this.chkAutoScaleY.Text = "Auto Scale Y Enabled";
            this.chkAutoScaleY.UseVisualStyleBackColor = true;
            this.chkAutoScaleY.CheckedChanged += new System.EventHandler(this.chkAutoScaleX_CheckedChanged);
            // 
            // frmScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 509);
            this.Controls.Add(this.chkAutoScaleY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updSamplingFrequency);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPlotEnabled);
            this.Controls.Add(this.treeViewDataSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updXScale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updYScale);
            this.Controls.Add(this.zedGraphControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScope";
            this.Text = "Scope";
            this.DockStateChanged += new System.EventHandler(this.frmScope_DockStateChanged);
            this.Load += new System.EventHandler(this.frmScope_Load);
            this.VisibleChanged += new System.EventHandler(this.frmScope_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.updYScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updXScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updSamplingFrequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.NumericUpDown updYScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown updXScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeViewDataSource;
        private System.Windows.Forms.Button btnPlotEnabled;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown updSamplingFrequency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAutoScaleY;

    }
}