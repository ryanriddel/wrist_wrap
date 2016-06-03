namespace wrapdoc
{
    partial class frmSerialConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSerialConnection));
            this.serialConnectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serialConnectTextBox = new System.Windows.Forms.RichTextBox();
            this.baudRateTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPortComboBox = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.serialHandler = new System.ComponentModel.BackgroundWorker();
            this.txtSerialOutput = new System.Windows.Forms.TextBox();
            this.btnSendSerialMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialConnectButton
            // 
            this.serialConnectButton.Location = new System.Drawing.Point(42, 97);
            this.serialConnectButton.Name = "serialConnectButton";
            this.serialConnectButton.Size = new System.Drawing.Size(182, 23);
            this.serialConnectButton.TabIndex = 2;
            this.serialConnectButton.Text = "Connect";
            this.serialConnectButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Port:";
            // 
            // serialConnectTextBox
            // 
            this.serialConnectTextBox.Location = new System.Drawing.Point(8, 136);
            this.serialConnectTextBox.Name = "serialConnectTextBox";
            this.serialConnectTextBox.ReadOnly = true;
            this.serialConnectTextBox.Size = new System.Drawing.Size(253, 44);
            this.serialConnectTextBox.TabIndex = 3;
            this.serialConnectTextBox.Text = "";
            // 
            // baudRateTextBox
            // 
            this.baudRateTextBox.Location = new System.Drawing.Point(103, 57);
            this.baudRateTextBox.Name = "baudRateTextBox";
            this.baudRateTextBox.Size = new System.Drawing.Size(121, 20);
            this.baudRateTextBox.TabIndex = 5;
            this.baudRateTextBox.Text = "112500";
            this.baudRateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate:";
            // 
            // serialPortComboBox
            // 
            this.serialPortComboBox.FormattingEnabled = true;
            this.serialPortComboBox.Location = new System.Drawing.Point(103, 19);
            this.serialPortComboBox.Name = "serialPortComboBox";
            this.serialPortComboBox.Size = new System.Drawing.Size(121, 21);
            this.serialPortComboBox.TabIndex = 0;
            // 
            // serialHandler
            // 
            this.serialHandler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.serialHandler_DoWork);
            // 
            // txtSerialOutput
            // 
            this.txtSerialOutput.Location = new System.Drawing.Point(8, 198);
            this.txtSerialOutput.Multiline = true;
            this.txtSerialOutput.Name = "txtSerialOutput";
            this.txtSerialOutput.Size = new System.Drawing.Size(253, 46);
            this.txtSerialOutput.TabIndex = 6;
            // 
            // btnSendSerialMessage
            // 
            this.btnSendSerialMessage.Location = new System.Drawing.Point(42, 261);
            this.btnSendSerialMessage.Name = "btnSendSerialMessage";
            this.btnSendSerialMessage.Size = new System.Drawing.Size(182, 23);
            this.btnSendSerialMessage.TabIndex = 7;
            this.btnSendSerialMessage.Text = "Send";
            this.btnSendSerialMessage.UseVisualStyleBackColor = true;
            this.btnSendSerialMessage.Click += new System.EventHandler(this.btnSendSerialMessage_Click);
            // 
            // frmSerialConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 288);
            this.Controls.Add(this.btnSendSerialMessage);
            this.Controls.Add(this.txtSerialOutput);
            this.Controls.Add(this.serialConnectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serialConnectTextBox);
            this.Controls.Add(this.serialPortComboBox);
            this.Controls.Add(this.baudRateTextBox);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSerialConnection";
            this.Text = "Serial Connection";
            this.Load += new System.EventHandler(this.frmSerialConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button serialConnectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox serialConnectTextBox;
        private System.Windows.Forms.TextBox baudRateTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox serialPortComboBox;
        public System.IO.Ports.SerialPort serialPort;
        private System.ComponentModel.BackgroundWorker serialHandler;
        private System.Windows.Forms.TextBox txtSerialOutput;
        private System.Windows.Forms.Button btnSendSerialMessage;
    }
}