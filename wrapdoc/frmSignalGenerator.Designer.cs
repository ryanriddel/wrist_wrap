namespace wrapdoc
{
    partial class frmSignalGenerator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignalGenerator));
            this.cboSignalType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmplitude = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboSignalType
            // 
            this.cboSignalType.FormattingEnabled = true;
            this.cboSignalType.Items.AddRange(new object[] {
            "Sinusoidal"});
            this.cboSignalType.Location = new System.Drawing.Point(88, 16);
            this.cboSignalType.Name = "cboSignalType";
            this.cboSignalType.Size = new System.Drawing.Size(144, 21);
            this.cboSignalType.TabIndex = 0;
            this.cboSignalType.Text = "Sinusoidal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Signal Type:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Enable";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Frequency:";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(132, 62);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtFrequency.TabIndex = 4;
            this.txtFrequency.Text = "100";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amplitude:";
            // 
            // txtAmplitude
            // 
            this.txtAmplitude.Location = new System.Drawing.Point(132, 99);
            this.txtAmplitude.Name = "txtAmplitude";
            this.txtAmplitude.Size = new System.Drawing.Size(100, 20);
            this.txtAmplitude.TabIndex = 6;
            this.txtAmplitude.Text = "1";
            // 
            // frmSignalGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 240);
            this.Controls.Add(this.txtAmplitude);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFrequency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSignalType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSignalGenerator";
            this.Text = "Signal Generator";
            this.Load += new System.EventHandler(this.frmSignalGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSignalType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmplitude;
    }
}